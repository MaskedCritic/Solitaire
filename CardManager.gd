extends Node2D

const COLLISION_MASK_CARD = 1
const COLLISION_MASK_CARD_SLOT = 2
var screen_size
var card_being_dragged
var is_hovering_on_card

func _input(event):
	if event is InputEventMouseButton and event.button_index == MOUSE_BUTTON_LEFT:
		if event.pressed:
			var card = check_for_card(COLLISION_MASK_CARD)
			if card:
				#game logic required here to allow snap back
				start_drag(card)
		else:
			#game logic required here to snap back to old position if invalid placement
			if (card_being_dragged):
				stop_drag()

func check_for_card(card_type):
	var space_state = get_world_2d().direct_space_state
	var parameters = PhysicsPointQueryParameters2D.new()
	parameters.position = get_global_mouse_position()
	parameters.collide_with_areas = true;
	parameters.collision_mask = card_type;
	var result = space_state.intersect_point(parameters)
	if result.size() > 0:
		return get_card_with_highest_z_index(result)
	return null

func get_card_with_highest_z_index(cards):
	var highest_z_card = cards[0].collider.get_parent()
	var highest_z_index = highest_z_card.z_index
	
	for i in range(1, cards.size()):
		var current_card = cards[i].collider.get_parent()
		if (current_card.z_index > highest_z_index):
			highest_z_card = current_card
			highest_z_index = current_card.z_index
	
	return highest_z_card

func connect_card_signals(card):
	card.connect("hovered", on_hovered_on_card)
	card.connect("hovered_off", on_hovered_off_card)

func on_hovered_on_card(card):
	if (!is_hovering_on_card):
		is_hovering_on_card = true
		highlight_card(card, true)

func on_hovered_off_card(card):
	if (!card_being_dragged):
		highlight_card(card, false)
		var new_card_hovered = check_for_card(COLLISION_MASK_CARD)
		if (new_card_hovered):
			highlight_card(new_card_hovered, true)
		else:
			is_hovering_on_card = false

func highlight_card(card, hovered):
	if (hovered):
		card.scale = Vector2(1.05, 1.05)
		card.z_index = 2
	else:
		card.scale = Vector2(1, 1)
		card.z_index = 1

func start_drag(card):
	card_being_dragged = card
	card.scale = Vector2(1, 1)
	if (card_being_dragged.is_in_slot):
		card_being_dragged.is_in_slot = false
		card_being_dragged.slot_card_is_in.card_in_slot = false
		card_being_dragged.slot_card_is_in = null
	

func stop_drag():
	card_being_dragged.scale = Vector2(1.05, 1.05)
	var card_slot_found = check_for_card(COLLISION_MASK_CARD_SLOT)
	if (card_slot_found && !card_slot_found.card_in_slot):
		card_being_dragged.position = card_slot_found.position
		card_being_dragged.is_in_slot = true
		card_being_dragged.slot_card_is_in = card_slot_found
		card_slot_found.card_in_slot = true
	card_being_dragged = null

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	screen_size = get_viewport_rect().size


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	if card_being_dragged:
		var mouse_position = get_global_mouse_position()
		card_being_dragged.position = Vector2(clamp(mouse_position.x, 0, screen_size.x), 
			clamp(mouse_position.y, 0, screen_size.y))

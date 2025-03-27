extends Node2D

signal left_mouse_button_clicked
signal left_mouse_button_released

const COLLISION_MASK_CARD = 1
const COLLISION_MASK_DECK = 4

var card_manager_reference
var pile_manager_reference

func _ready() -> void:
	card_manager_reference = $"../CardManager"
	pile_manager_reference = $"../PileManager"

func _input(event):
	if event is InputEventMouseButton and event.button_index == MOUSE_BUTTON_LEFT:
		if event.pressed:
			emit_signal("left_mouse_button_clicked")
			raycast_at_cursor()
			#var card = check_for_card(COLLISION_MASK_CARD)
			#if card:
				##game logic required here to allow snap back
				#start_drag(card)
		else:
			emit_signal("left_mouse_button_released")
			##game logic required here to snap back to old position if invalid placement
			#if (card_being_dragged):
				#stop_drag()

func raycast_at_cursor():
	var space_state = get_world_2d().direct_space_state
	var parameters = PhysicsPointQueryParameters2D.new()
	parameters.position = get_global_mouse_position()
	parameters.collide_with_areas = true;
	#parameters.collision_mask = card_type;
	var result = space_state.intersect_point(parameters)
	if result.size() > 0:
		var result_collision_mask = result[0].collider.collision_mask
		if (result_collision_mask == COLLISION_MASK_CARD):
			var card_found = result[0].collider.get_parent()
			if (card_found):
				card_manager_reference.start_drag(card_found)
			#get_card_with_highest_z_index(result)

#func get_card_with_highest_z_index(cards):
	#var highest_z_card = cards[0].collider.get_parent()
	#var highest_z_index = highest_z_card.z_index
	#
	#for i in range(1, cards.size()):
		#var current_card = cards[i].collider.get_parent()
		#if (current_card.z_index > highest_z_index):
			#highest_z_card = current_card
			#highest_z_index = current_card.z_index
	#
	#return highest_z_card

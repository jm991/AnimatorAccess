// GENERATED CODE ==> EDITS WILL BE LOST AFTER NEXT GENERATION!
// Version for Windows

using UnityEngine;


namespace AnimatorAccess {
    [Scio.CodeGeneration.GeneratedClassAttribute ("4/16/2018 7:20:48 PM")]
	/// <summary>
	/// Convenience class to access Animator states and parameters.
	/// Edits will be lost when this class is regenerated. 
	/// Hint: Editing might be useful after renaming animator items in complex projects:
	///  - Right click on an obsolete member and select Refactor/Rename. 
	///  - Change it to the new name. 
	///  - Delete this member to avoid comile error CS0102 ... already contains a definition ...''. 
	/// </summary>
	public class ExamplePlayerAnimatorAccess : BaseAnimatorAccess
    {
        /// <summary>
		/// Hash of Animator state Walking
		/// </summary>
		public readonly int stateIdWalking = 1744665739;
		
        /// <summary>
		/// Hash of Animator state Idle
		/// </summary>
		public readonly int stateIdIdle = 2081823275;
		
        /// <summary>
		/// Hash of Animator state Yawning
		/// </summary>
		public readonly int stateIdYawning = 388780407;
		
        /// <summary>
		/// Hash of Animator state Jumping
		/// </summary>
		public readonly int stateIdJumping = 1137391654;
		
        /// <summary>
		/// Hash of Animator state Rotate-Left
		/// </summary>
		public readonly int stateIdRotate_Left = 1491709478;
		
        /// <summary>
		/// Hash of Animator state Rotate-Right
		/// </summary>
		public readonly int stateIdRotate_Right = 629970890;
		
        /// <summary>
		/// Hash of Animator state Centered
		/// </summary>
		public readonly int stateIdCentered = 751489196;
		
        /// <summary>
		/// Hash of parameter Speed
		/// </summary>
		public readonly int paramIdSpeed = -823668238;
		
        /// <summary>
		/// Hash of parameter JumpTrigger
		/// </summary>
		public readonly int paramIdJumpTrigger = 113680519;
		
        /// <summary>
		/// Hash of parameter YawnTrigger
		/// </summary>
		public readonly int paramIdYawnTrigger = 1330169897;
		
        /// <summary>
		/// Hash of parameter Rotate
		/// </summary>
		public readonly int paramIdRotate = 807753530;
		
		
		
		public override int AllTransitionsHash { 
			get{ return 98844776; }
		}
		
		
		public void Awake () { 
			animator = GetComponent<Animator> ();
		}
		
		public override void InitialiseEventManager () { 
			StateInfos.Add (1744665739, new StateInfo (1744665739, 0, "Base Layer", "Walking", "", 1f, false, false, "Walk", 1.208333f));
			StateInfos.Add (2081823275, new StateInfo (2081823275, 0, "Base Layer", "Idle", "", 1f, false, false, "Idle", 2.708333f));
			StateInfos.Add (388780407, new StateInfo (388780407, 0, "Base Layer", "Yawning", "", 1f, false, false, "Yawn", 2.291667f));
			StateInfos.Add (1137391654, new StateInfo (1137391654, 0, "Base Layer", "Jumping", "", 1f, false, false, "Jump", 0.7916667f));
			StateInfos.Add (1491709478, new StateInfo (1491709478, 1, "Rot", "Rotate-Left", "", 1f, false, false, "Rotate-Left", 0.1666667f));
			StateInfos.Add (629970890, new StateInfo (629970890, 1, "Rot", "Rotate-Right", "", 1f, false, false, "Rotate-Right", 0.1666667f));
			StateInfos.Add (751489196, new StateInfo (751489196, 1, "Rot", "Centered", "", 1f, false, false, "Centered", 0.1666667f));
			TransitionInfos.Add (0, new TransitionInfo (0, "", 0, "Base Layer", 0, 388780407, false, 0.25f, false, 0f, false));
		}
		
		/// <summary>
		/// true if the current Animator state of layer 0 is  "Walking".
		/// </summary>
		public bool IsWalking () { 
			return stateIdWalking == animator.GetCurrentAnimatorStateInfo (0).nameHash;
		}
		
		/// <summary>
		/// true if the given (state) nameHash equals Animator.StringToHash ("Walking").
		/// </summary>
		public bool IsWalking (int nameHash) { 
			return nameHash == stateIdWalking;
		}
		
		/// <summary>
		/// true if the current Animator state of layer 0 is  "Idle".
		/// </summary>
		public bool IsIdle () { 
			return stateIdIdle == animator.GetCurrentAnimatorStateInfo (0).nameHash;
		}
		
		/// <summary>
		/// true if the given (state) nameHash equals Animator.StringToHash ("Idle").
		/// </summary>
		public bool IsIdle (int nameHash) { 
			return nameHash == stateIdIdle;
		}
		
		/// <summary>
		/// true if the current Animator state of layer 0 is  "Yawning".
		/// </summary>
		public bool IsYawning () { 
			return stateIdYawning == animator.GetCurrentAnimatorStateInfo (0).nameHash;
		}
		
		/// <summary>
		/// true if the given (state) nameHash equals Animator.StringToHash ("Yawning").
		/// </summary>
		public bool IsYawning (int nameHash) { 
			return nameHash == stateIdYawning;
		}
		
		/// <summary>
		/// true if the current Animator state of layer 0 is  "Jumping".
		/// </summary>
		public bool IsJumping () { 
			return stateIdJumping == animator.GetCurrentAnimatorStateInfo (0).nameHash;
		}
		
		/// <summary>
		/// true if the given (state) nameHash equals Animator.StringToHash ("Jumping").
		/// </summary>
		public bool IsJumping (int nameHash) { 
			return nameHash == stateIdJumping;
		}
		
		/// <summary>
		/// true if the current Animator state of layer 1 is  "Rotate-Left".
		/// </summary>
		public bool IsRotate_Left () { 
			return stateIdRotate_Left == animator.GetCurrentAnimatorStateInfo (1).nameHash;
		}
		
		/// <summary>
		/// true if the given (state) nameHash equals Animator.StringToHash ("Rotate-Left").
		/// </summary>
		public bool IsRotate_Left (int nameHash) { 
			return nameHash == stateIdRotate_Left;
		}
		
		/// <summary>
		/// true if the current Animator state of layer 1 is  "Rotate-Right".
		/// </summary>
		public bool IsRotate_Right () { 
			return stateIdRotate_Right == animator.GetCurrentAnimatorStateInfo (1).nameHash;
		}
		
		/// <summary>
		/// true if the given (state) nameHash equals Animator.StringToHash ("Rotate-Right").
		/// </summary>
		public bool IsRotate_Right (int nameHash) { 
			return nameHash == stateIdRotate_Right;
		}
		
		/// <summary>
		/// true if the current Animator state of layer 1 is  "Centered".
		/// </summary>
		public bool IsCentered () { 
			return stateIdCentered == animator.GetCurrentAnimatorStateInfo (1).nameHash;
		}
		
		/// <summary>
		/// true if the given (state) nameHash equals Animator.StringToHash ("Centered").
		/// </summary>
		public bool IsCentered (int nameHash) { 
			return nameHash == stateIdCentered;
		}
		
		/// <summary>
		/// Set float parameter of Speed using damp and delta time .
		/// <param name="newValue">New value for float parameter Speed.</param>
		/// <param name="dampTime">The time allowed to parameter Speed to reach the value.</param>
		/// <param name="deltaTime">The current frame deltaTime.</param>
		/// </summary>
		public void SetSpeed (float newValue, float dampTime, float deltaTime) { 
			animator.SetFloat (paramIdSpeed, newValue, dampTime, deltaTime);
		}
		
		/// <summary>
		/// Set float value of parameter Speed.
		/// <param name="newValue">New value for float parameter Speed.</param>
		/// </summary>
		public void SetSpeed (float newValue) { 
			animator.SetFloat (paramIdSpeed, newValue);
		}
		
		/// <summary>
		/// Access to float parameter Speed, default is: 0.
		/// </summary>
		public float GetSpeed () { 
			return animator.GetFloat (paramIdSpeed);
		}
		
		/// <summary>
		/// Activate trigger of parameter JumpTrigger.
		/// </summary>
		public void SetJumpTrigger () { 
			animator.SetTrigger (paramIdJumpTrigger);
		}
		
		/// <summary>
		/// Activate trigger of parameter YawnTrigger.
		/// </summary>
		public void SetYawnTrigger () { 
			animator.SetTrigger (paramIdYawnTrigger);
		}
		
		/// <summary>
		/// Set integer value of parameter Rotate.
		/// <param name="newValue">New value for integer parameter Rotate.</param>
		/// </summary>
		public void SetRotate (int newValue) { 
			animator.SetInteger (paramIdRotate, newValue);
		}
		
		/// <summary>
		/// Access to integer parameter Rotate, default is: 1.
		/// </summary>
		public int GetRotate () { 
			return animator.GetInteger (paramIdRotate);
		}
		
		private void FixedUpdate () { 
			CheckForAnimatorStateChanges ();
		}
		
        
    }
}



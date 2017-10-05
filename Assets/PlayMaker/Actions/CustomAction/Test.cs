using DragonBones;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

    [ActionCategory("CustomAction")]
    [Tooltip("Plays a state. This could be used to synchronize your animation with audio or synchronize an Animator over the network.")]
    public class Test : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(UnityArmatureComponent))]
        [Tooltip("The target. Unity Armature Component is required")]
        public FsmOwnerDefault gameObject;

        [Tooltip("The name of the state that will be played.")]
        public FsmString stateName;

        [Tooltip("The layer where the state is.")]
        public FsmInt layer;

        [Tooltip("The normalized time at which the state will play")]
        public FsmFloat normalizedTime;

        [Tooltip("Repeat every frame. Useful when using normalizedTime to manually control the animation.")]
        public bool everyFrame;

        UnityArmatureComponent _animator;

        public override void Reset()
        {
            gameObject = null;
            stateName = null;
            layer = new FsmInt() { UseVariable = true };
            normalizedTime = new FsmFloat() { UseVariable = true };
            everyFrame = false;
        }

        // Code that runs on entering the state.
        public override void OnEnter()
	    {
            // get the UnityArmatureComponent
            var go = Fsm.GetOwnerDefaultTarget(gameObject);

            if (go == null)
            {
                Finish();
                return;
            }

            _animator = go.GetComponent<UnityArmatureComponent>();

            DoAnimatorPlay();
            if (!everyFrame)
            {
                Finish();
            }
        }

	    // Code that runs every frame.
	    public override void OnUpdate()
	    {
            DoAnimatorPlay();
        }

        void DoAnimatorPlay()
        {
            if (_animator != null)
            {
                int _layer = layer.IsNone ? -1 : layer.Value;

                float _normalizedTime = normalizedTime.IsNone ? Mathf.NegativeInfinity : normalizedTime.Value;

                //_animator.Play(stateName.Value, _layer, _normalizedTime);
                _animator.animationName = stateName.Value;

                _animator.animation.Play(_animator.animationName, -1);
            }

        }


    }

}

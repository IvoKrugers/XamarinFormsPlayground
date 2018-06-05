using System.Collections.Generic;
using System.Threading.Tasks;
using Xamanimation;
using Xamarin.Forms;

namespace Playground.Helpers
{
    [ContentProperty("Animations")]
    public class ParallelStoryBoard : AnimationBase
    {
        public ParallelStoryBoard()
        {
            PreAnimations = new List<AnimationBase>();
            Animations = new List<AnimationBase>();
            PostAnimations = new List<AnimationBase>();
        }

        public ParallelStoryBoard(List<AnimationBase> animations)
        {
            Animations = animations;
        }

        public List<AnimationBase> PreAnimations { get; }

        public List<AnimationBase> Animations { get; }

        public List<AnimationBase> PostAnimations { get; }

        protected override async Task BeginAnimation()
        {
            foreach (var animation in PreAnimations)
            {
                if (animation.Target == null)
                    animation.Target = Target;

                await animation.Begin();
            }
            
            var animationTasks = new List<Task>();
            foreach (var animation in Animations)
            {
                if (animation.Target == null)
                    animation.Target = Target;

                animationTasks.Add(animation.Begin());
            }
            await Task.WhenAll(animationTasks);

            foreach (var animation in PostAnimations)
            {
                if (animation.Target == null)
                    animation.Target = Target;

                await animation.Begin();
            }
        }
    }
}

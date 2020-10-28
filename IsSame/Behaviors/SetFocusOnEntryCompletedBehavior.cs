using System;
using Xamarin.Forms;

// Entry에서 입력후에 엔터키를 쳤을 때 포커스를 다음 엔트리로 바꾸기 위한 메서드
// https://adenearnshaw.com/focus-next-element-on-enter/
namespace CrossCheckVer1.Behavoirs
{
    public class SetFocusOnEntryCompletedBehavior : BehaviorBase<Entry>
    {
        public SetFocusOnEntryCompletedBehavior()
        {
        }

        public static readonly BindableProperty TargetElementProperty
            = BindableProperty.Create(nameof(TargetElement), typeof(VisualElement), typeof(SetFocusOnEntryCompletedBehavior));

        public VisualElement TargetElement
        {
            get => (VisualElement)GetValue(TargetElementProperty);
            set => SetValue(TargetElementProperty, value);
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject.Completed += Entry_Completed;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            AssociatedObject.Completed -= Entry_Completed;
            base.OnDetachingFrom(bindable);
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            TargetElement?.Focus();
        }
    }
}

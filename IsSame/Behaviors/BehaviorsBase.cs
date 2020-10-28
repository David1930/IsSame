using System;
using Xamarin.Forms;

// Entry에서 입력후에 엔터키를 쳤을 때 포커스를 다음 엔트리로 바꾸기 위한 메서드
// https://adenearnshaw.com/focus-next-element-on-enter/
namespace CrossCheckVer1.Behavoirs
{
    public class BehaviorBase<T> : Behavior<T> where T : BindableObject
    {
        public BehaviorBase()
        {
        }

        public T AssociatedObject { get; private set; }

        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;

            if (bindable.BindingContext != null)
                BindingContext = bindable.BindingContext;

            bindable.BindingContextChanged += OnBindingContextChanged;
        }

        protected override void OnDetachingFrom(T bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= OnBindingContextChanged;
            AssociatedObject = null;
        }


        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }

    }
}

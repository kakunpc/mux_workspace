using Mux;
using Mux.Markup;
using System.ComponentModel;

namespace Main
{
    [UnityEngine.RequireComponent(typeof(UnityEngine.Canvas))]
    internal sealed class Main : UnityEngine.MonoBehaviour
    {
        private MainViewModel _viewModel;

#pragma warning disable CS0649
        [UnityEngine.SerializeField]
        private UnityEngine.Font _font;
#pragma warning restore CS0649

        private void Awake()
        {
            _viewModel = new MainViewModel {Font = _font};
            var transform = new MainTransform();
            transform.BindingContext = _viewModel;
            transform.X = new Stretch();
            transform.Y = new Stretch();
            transform.AddTo(gameObject);
        }

        private void OnValidate()
        {
            if (_viewModel != null)
            {
                _viewModel.Font = _font;
            }
        }
    }

    internal sealed class MainViewModel : INotifyPropertyChanged
    {
        private UnityEngine.Font _font;

        public UnityEngine.Font Font
        {
            get => _font;
            set
            {
                _font = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Font)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    internal sealed class MainTransform : RectTransform, IReloadable
    {
        [XamlImport] private extern void InitializeComponent();

        public MainTransform()
        {
            InitializeComponent();
        }

        public void Reload()
        {
            InitializeComponent();
        }
    }
}
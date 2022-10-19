using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DecaratorPattern
{
    public partial class MainWindow : Window
    {
        class Item
        {
            public string Message { get; set; }
            public string ImagePath { get; set; }
        }

        interface IService
        {
            List<Item> GetItems(string Message);
        }


        class Service : IService
        {
            public List<Item> GetItems(string Message)
            {
                return new List<Item>();
            }
        }

        class ServiceDecarator : IService
        {

            public IService _service;
            public ServiceDecarator(IService service)
            {
                _service = service;
            }
            public virtual List<Item> GetItems(string Message)
            {
                return _service.GetItems( Message);
            }
        }

        class SmsServiceDecarator : ServiceDecarator
        {
            public SmsServiceDecarator(IService service) : base(service)
            {

            }

            public override List<Item> GetItems(string Message)
            {
                Item item = new Item
                {
                    ImagePath = "Images/sms.png",
                    Message = $"{Message} From SmsService"
                };
                var items = _service.GetItems( Message);
                items.Add(item);
                return items;
            }
        }

        class FacebookServiceDecarator : ServiceDecarator
        {
            public FacebookServiceDecarator(IService service) : base(service)
            {

            }

            public override List<Item> GetItems(string Message)
            {
                Item item = new Item
                {
                    ImagePath = "Images/facebook.png",
                    Message = $"{Message} From FacebookService"
                };
                var items = _service.GetItems(Message);
                items.Add(item);
                return items;
            }
        }

        class InstagramServiceDecarator : ServiceDecarator
        {
            public InstagramServiceDecarator(IService service) : base(service)
            {

            }

            public override List<Item> GetItems(string Message)
            {
                Item item = new Item
                {
                    ImagePath = "Images/instagram.png",
                    Message = $"{Message} InstagramService"
                };
                var items = _service.GetItems(Message);
                items.Add(item);
                return items;
            }
        }

        class TwitterServiceDecarator : ServiceDecarator
        {
            public TwitterServiceDecarator(IService service) : base(service)
            {

            }

            public override List<Item> GetItems(string Message)
            {
                Item item = new Item
                {
                    ImagePath = "Images/twitter.png",
                    Message = $"{Message} From TwitterService"
                };
                var items = _service.GetItems(Message);
                items.Add(item);
                return items;
            }
        }


        public RelayCommand SendMessageCommand { get; set; }
        private IService service = new Service();
        private ServiceDecarator decarator { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            SendMessageCommand = new RelayCommand((e) =>
            {
                if(SmsService.IsChecked == true)
                {
                    IService SmsService = new SmsServiceDecarator(decarator);
                    service = SmsService;
                    decarator = new ServiceDecarator(service);
                }
                if(FacebookService.IsChecked == true)
                {
                    IService FacebookService = new FacebookServiceDecarator(decarator);
                    service = FacebookService;
                    decarator = new ServiceDecarator(service);
                }
                if(InstagramService.IsChecked == true)
                {
                    IService InstagramService = new InstagramServiceDecarator(decarator);
                    service = InstagramService;
                    decarator = new ServiceDecarator(service);
                }
                if(TwitterService.IsChecked == true)
                {
                    IService TwitterService = new TwitterServiceDecarator(decarator);
                    service = TwitterService;
                    decarator = new ServiceDecarator(service);
                }

                List<Item> Items = decarator.GetItems(TextBox1.Text);
                service = new Service();
                decarator = new ServiceDecarator(service);

                ItemsListView.ItemsSource = null;
                ItemsListView.ItemsSource = Items;

            }, (e) =>
            {
                return TextBox1.Text != string.Empty;
            });

            decarator = new ServiceDecarator(service);

        }

    }
}

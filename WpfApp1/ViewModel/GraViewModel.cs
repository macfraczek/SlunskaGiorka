using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{
    using System.ComponentModel;
    using WpfApp1.Model;
    using WpfApp1.Commands;
    using System.Windows.Input;

    class GraViewModel: INotifyPropertyChanged
    {
        Gra _gra = new Gra();
        public List<String> BuildsList = new List<String>();

        public String DayInGame { get { return String.Format("Dziyń: {0}", _gra.Day); } }
        public String MoneyInGame { get { return String.Format("Miedźioki: {0}", _gra.Money);} }
        public string[] ImgPath { get => _gra.ImgPath; }
        public NewDayCommand NextDay { get; set; }
        public ICommand BuildNowCommand { get; set; }
        public int NumerOfQuarry { get => Quarry.Instance.Count; }
        public int NumerOfWoodCutter { get => Woodcutter.Instance.Count; }
        public int NumerOfSawmill { get => Sawmill.Instance.Count; }
        public int NumerOfGoldMine { get => GoldMine.Instance.Count; }
        public int NumerOfMint { get => Mint.Instance.Count; }
        public int BuildX { get; set; }
        public int BuildY { get; set; }
        public String BuildType { get; set; }
        public List<String> BuildsListProvider { get => BuildsList; }
        

        public GraViewModel()
        {
            NextDay = new NewDayCommand(NewDayVM);
            BuildNowCommand = new BuildCommand(BuildVM);
            BuildsListProvider.Add("Kamieniołom");
            BuildsListProvider.Add("Chatka Drwala");
            BuildsListProvider.Add("Tartak");
            BuildsListProvider.Add("Kopalnia złota");
            BuildsListProvider.Add("Mennica");
        }
        
        private void NewDayVM()
        {
            _gra.NewDay();
            OnPropertyChanged("DayInGame");
            OnPropertyChanged("MoneyInGame");
        }
        private void BuildVM()
        {
            /*//System.Windows.MessageBox.Show("Sorry,not implemented yet :(", "under developing",System.Windows.MessageBoxButton.OK,System.Windows.MessageBoxImage.Information);
            
            bool IsEmptyField = _gra.IsEmptyField(BuildX, BuildY);
            bool IsEnoughtMoney = false;
            if (_gra.Money > (Mapper.BuildingStringToBuildingMapper(BuildType)).Cost)
            {
                IsEnoughtMoney = true;
            }
            
                System.Windows.MessageBox.Show(String.Format("Error {0}", Mapper.BuildingStringToBuildingMapper(BuildType).Cost));

            if (IsEmptyField && IsEnoughtMoney)
            {
                _gra.SetField(BuildX, BuildY, (Mapper.BuildingStringToEnumMapper(BuildType)));

                _gra.PayForBuild(Mapper.BuildingStringToBuildingMapper(BuildType).Cost);
                
                OnPropertyChanged("MoneyInGame");
                OnPropertyChanged("ImgPath");
                OnPropertyChanged("NumerOfQuarry");
                OnPropertyChanged("NumerOfWoodCutter");
                OnPropertyChanged("NumerOfSawmill");
                OnPropertyChanged("NumerOfGoldMine");
                OnPropertyChanged("NumerOfMint");
            }
            //_gra.PayForBuild(Mapper.BuildingStringToBuildingMapper(BuildType).Cost);
            //OnPropertyChanged("MoneyInGame");*/

            _gra.BuildNow(BuildX, BuildY, Mapper.BuildingStringToEnumMapper(BuildType));
            OnPropertyChanged("MoneyInGame");
            OnPropertyChanged("ImgPath");
            OnPropertyChanged("NumerOfQuarry");
            OnPropertyChanged("NumerOfWoodCutter");
            OnPropertyChanged("NumerOfSawmill");
            OnPropertyChanged("NumerOfGoldMine");
            OnPropertyChanged("NumerOfMint");
        }




        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

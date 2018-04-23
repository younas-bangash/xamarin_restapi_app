using APICall.Core.PCL.ModelClasses;
using Newtonsoft.Json;
using RefitXFSample.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;


namespace RefitXFSample.ViewModels
{
    public class MainPageViewModel: BaseViewModel
    {
        public ObservableCollection<MakeUp> MakeUps {get;set;}

        public ICommand GetDataCommand {get; set;}

        public MainPageViewModel() 
        {
            GetDataCommand= new Command(async()=> await RunSafe(GetData()));
        }

        async Task GetData(){

            var makeUpsResponse = await ApiManager.GetMakeUps("maybelline");

            if(makeUpsResponse.IsSuccessStatusCode){
                var response = await makeUpsResponse.Content.ReadAsStringAsync();
                var json = await Task.Run(() => JsonConvert.DeserializeObject<List<MakeUp>>(response));
                MakeUps = new ObservableCollection<MakeUp>(json);
            }else{
                await PageDialog.AlertAsync("Unable to get data", "Error", "Ok");
            }
        }
    }
}

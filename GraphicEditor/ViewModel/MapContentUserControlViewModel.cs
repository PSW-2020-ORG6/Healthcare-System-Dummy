﻿using GraphicEditor.HelpClasses;

namespace GraphicEditor.ViewModel
{
    public class MapContentUserControlViewModel : BindableBase
    {
        public static CardiologyBuildingUserControlViewModel CardiologyBuilding;
        public static HospitalMapUserControlViewModel HospitalMap;
        private BindableBase _contentViewModel;

        public MapContentUserControlViewModel()
        {
            CardiologyBuilding = new CardiologyBuildingUserControlViewModel(this);
            HospitalMap = new HospitalMapUserControlViewModel(this);
            _contentViewModel = HospitalMap;
        }

        public BindableBase ContentViewModel
        {
            get { return _contentViewModel; }
            set
            {
                SetProperty(ref _contentViewModel, value);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WonderfulWinds.Scraper.Model;
using WonderfulWinds.Scraper.Model.Entities;

namespace WonderfulWinds.Scraper.Repository
{
    public class WonderfulWIndsRepository : IRepository
    {
        private static WonderfulWindsModel[] _model = new WonderfulWindsModel[2];
        private static int _currentModel = 0;
        private static int _latestModel = -1;

        /// <summary>
        /// Alternate between models
        /// </summary>
        public static WonderfulWindsModel Model
        {
            get
            {
                if (_latestModel == -1) return null;
                return _model[_latestModel];
            }
            set
            {
                _model[_currentModel] = value;
                if (_currentModel == 0)
                {
                    _currentModel = 1;
                    _latestModel = 0;
                }
                else
                {
                    _currentModel = 0;
                    _latestModel = 1;
                }
            }
        }

        private static object lockObject = new object();
        private static Timer _timer = new Timer();

        public WonderfulWIndsRepository()
        {
            InitialiseModel();
        }

        static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Model = new WonderfulWindsModel();
        }

        public void InitialiseModel()
        {
            Model = new WonderfulWindsModel();
            _timer_Elapsed(null, null);
            _timer.Interval = 1000 * 60 * 60;
            _timer.Enabled = true;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();

        }




        #region IRepository Members

        public int GetMenuItemCount()
        {
            if (Model == null) return 0;
            return Model.GetMenuCount();

        }

        public List<string> GetMenuItems()
        {

            if (Model == null) return null;
            return Model.GetMenu();

        }

       

        public MenuItem GetMenuItem(int index)
        {

            if (Model == null) return null;
            return Model.GetMenuItem(index);

        }

        #endregion
    }
}

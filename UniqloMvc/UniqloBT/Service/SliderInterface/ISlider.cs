using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqloDAL.Models;

namespace UniqloBT.Service.SliderInterface
{
    public interface ISlider
    {
        public List<Slider> GetAllData();
        
    }
}

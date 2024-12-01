using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqloBT.Service.SliderInterface;
using UniqloDAL.DAL;
using UniqloDAL.Models;

namespace UniqloBT.Service.SliderMedhod
{
    public class SliderService : ISlider
    {
        private readonly AppDbContext _context;

        public SliderService(AppDbContext context)
        {
            _context = context;
        }

        public List<Slider> GetAllData()
        {
            
            var sliders = _context.Sliders.ToList();
            return sliders;
        }
    }
}

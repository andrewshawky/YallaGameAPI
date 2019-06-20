using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Dtos;
using YallaGameAPISecure.Models;
using YallaGameAPISecure.Repository;

namespace YallaGameAPISecure.BLL
{
    public class ReviewPlaceManager : ModelRepository2<ReviewPlace, yallagameContext>
    {
        DbContext context;
        //here any logic you want to add or overide it 
        public ReviewPlaceManager(yallagameContext context) : base(context)
        {
            this.context = context;
        }



        public List<PlaceReviewDto> GetReviewsByPlaceId(int id)
        {
            List<ReviewPlace> res = getAll().Where(i => i.PlaceId == id).ToList();


            
            List<PlaceReviewDto> xlist = new List<PlaceReviewDto>();
            PlaceReviewDto x = new PlaceReviewDto();


            foreach (ReviewPlace i in res)
            {
                x.PlaceId = i.PlaceId;
                x.UserId = i.UserId;
                x.Content = i.Content;
                xlist.Add(x);
            }
            
            return xlist;
        }
    }
    
}

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


        //send place id and return reviews of this place 
        public List<PlaceReviewDto> GetReviewsByPlaceId(int id)
        {
            List<ReviewPlace> res = getAll().Where(i => i.PlaceId == id).ToList();


            
            List<PlaceReviewDto> xlist = new List<PlaceReviewDto>();
            PlaceReviewDto x ;


            foreach (ReviewPlace i in res)
            {
                
                User user = context.Set<User>().Find(i.UserId);
               
                x = new PlaceReviewDto();
                x.PlaceId = i.PlaceId;
                x.UserId = i.UserId;
                x.Content = i.Content;
                x.Rate = i.Rate;
                x.Image = user.Image;
                x.UserName = user.Name;
                

                xlist.Add(x);
            }
            
            return xlist;
        }
    }
    
}

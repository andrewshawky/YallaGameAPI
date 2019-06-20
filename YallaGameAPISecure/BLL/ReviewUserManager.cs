using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Dtos;
using YallaGameAPISecure.Models;
using YallaGameAPISecure.Repository;

namespace YallaGameAPISecure.BLL
{
    public class ReviewUserManager : ModelRepository2<ReviewUser, yallagameContext>
    {
        //here any logic you want to add or overide it 
        public ReviewUserManager(yallagameContext context) : base(context)
        {

        }

        public List<UserReviewDto> GetReviewsByUserId(int id)
        {
            List<ReviewUser> res = getAll().Where(i => i.UserId == id).ToList();


            
            List<UserReviewDto> xlist = new List<UserReviewDto>();
            UserReviewDto x ;


            foreach (ReviewUser i in res)
            {
                x = new UserReviewDto();
                x.UserId = i.UserId;
                x.UserId = i.UserId;
                x.Content = i.Content;
                x.Rate = i.Rate;

                xlist.Add(x);
            }
            
            return xlist;
        }
    }
   
}

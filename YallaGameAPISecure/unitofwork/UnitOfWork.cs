using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.BLL;
using YallaGameAPISecure.Models;

namespace YallaGameAPISecure.unitofwork
{
    public class UnitOfWork
    {
        static UnitOfWork unit;
        yallagameContext context;


        private UnitOfWork()//private to prevent user to create object using new 
        {
            context = new yallagameContext(); //we call this constructor only one time because we can call it only one time 
        }

        public static UnitOfWork CreateInstance()//singleton 
        {
            if (unit == null)
            {
                unit = new UnitOfWork();
                return unit; // if null return object from this class
            }
            return unit; //return the element that is already exist
        }

        public UserManager UserManager
        {
            get
            {
                return new UserManager(context);
            }
        }

        public PlaceManager PlaceManager
        {
            get
            {
                return new PlaceManager(context);
            }
        }

        public GameManager GameManager
        {
            get
            {
                return new GameManager(context);
            }
        }

        public InvitationManager InvitationManager
        {
            get
            {
                return new InvitationManager(context);
            }
        }

        public ReviewUserManager ReviewUserManager
        {
            get
            {
                return new ReviewUserManager(context);
            }
        }

        public ChatManager ChatManager
        {
            get
            {
                return new ChatManager(context);
            }
        }

        public ReviewPlaceManager ReviewPlaceManager
        {
            get
            {
                return new ReviewPlaceManager(context);
            }
        }

        public OnlineUserManager OnlineUserManager
        {
            get
            {
                return new OnlineUserManager(context);
            }
        }

        public GroupChatManager GroupChatManager
        {
            get
            {
                return new GroupChatManager(context);
            }
        }
        
        public GameInPlaceManager GameInPlaceManager
        {
            get
            {
                return new GameInPlaceManager(context);
            }
        }

        public GameByUserManager GameByUserManager
        {
            get
            {
                return new GameByUserManager(context);
            }
        }

        public UserInvitationManager UserInvitationManager
        {
            get
            {
                return new UserInvitationManager(context);
            }
        }

        public ImageOfPlaceManager ImageOfPlaceManager
        {
            get
            {
                return new ImageOfPlaceManager(context);
            }
        }

        //public Employeemanager Employeemanager
        //{
        //    get {
        //        return new Employeemanager(context);
        //    }
        //}
    }
}

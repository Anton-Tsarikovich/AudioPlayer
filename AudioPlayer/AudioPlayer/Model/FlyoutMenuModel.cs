using System;
using System.Collections.Generic;
using System.Text;

namespace AudioPlayer
{
    public class FlyoutMenuModel
    {
        private string title;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if(value != "")
                {
                    title = value;
                }
            }
        }

        private Type targetType;

        public Type TargetType
        {
            get
            {
                return targetType;
            }
            set
            {
                targetType = value;
            }
        }
    }
}

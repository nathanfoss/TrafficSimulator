namespace TrafficApplication
{
    class TypeHandler
    {

        /// <summary>
        /// Constructor for the TypeHandler class. This class has no data members and simply 
        /// assigns an int size value based on the vehicle Type
        /// </summary>
        public TypeHandler()
        {

        }

        /// <summary>
        /// Gets the size of the vehicle assigned by the private method SetSize
        /// </summary>
        /// <param name="type">The Enumerated Type of the Vehicle</param>
        /// <returns>The size, in feet, of the vehicle</returns>
        public int GetSize(Type type)
        {
            int size = 0;
            size = SetSize(type, size);
            return size;
        }

        /// <summary>
        /// Sets the vehicle size based on the average size of different types of vehicles
        /// </summary>
        /// <param name="type">The Enumerated Type of Vehicle</param>
        /// <param name="size"></param>
        /// <returns>The size, in feet, of the vehicle</returns>
        private static int SetSize(Type type, int size)
        {
            switch (type)
            {
                case Type.COMPACT:
                    {
                        size = 13; //average compact car is 13 feet long
                        break;
                    }
                case Type.MINIVAN:
                    {
                        size = 17; //average minivan is 17 feet long
                        break;
                    }
                case Type.MOTORCYCLE:
                    {
                        size = 8; //average motorcycle is 8 feet long
                        break;
                    }
                case Type.PICKUP:
                    {
                        size = 18; //average pickup truck is 18 feet long
                        break;
                    }
                case Type.SEDAN:
                    {
                        size = 15; //average sedan is 15 feet long
                        break;
                    }
                case Type.SEMI:
                    {
                        size = 60; //average semi truck + trailer is 60 feet long
                        break;
                    }
            }

            return size;
        }
    }
}

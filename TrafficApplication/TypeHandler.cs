namespace TrafficApplication
{
    class TypeHandler
    {
        private int VehicleSize;

        public TypeHandler()
        {

        }

        public int GetSize(Type type)
        {
            int size = 0;
            size = SetSize(type, size);
            return size;
        }

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

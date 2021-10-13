using System;

namespace ext2
{
    public static class org_random_generator
    {
        public static int returnRandomNumber()
        {
            return new Random().Next();
        }
    }
}
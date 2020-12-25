using System;
using System.Collections.Generic;
using System.Text;

namespace ExeptionController
{
    public static class ExeptionController
    {
        public static void CrushSaveExeption()
        {
            throw new Exception("Ошибка сохранения данных");
        }

        public static void NullPointerExeption()
        {
            throw new Exception();
        }

        public static void UncorrectCheckUserExeption()
        {
            throw new Exception("Введен неправельный логин или пароль");
        }
    }
}

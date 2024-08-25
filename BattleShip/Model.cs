using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public enum ShotStatus // статус выстрела
    {
        Miss,      // мимо
        Wounded,   // ранил
        Kill,      // убил
        EndBattle  // конец боя
    }
    public enum CoordStatus // статус координат
    {
        None,    // пусто 
        Ship,    // корабль
        Shot,    // выстрел
        Got      // попал
    }
    public enum ShipType  // Типы кораблей
    {
        x4 = 1,    // количество палуб
        x3 = 2,
        x2 = 3,
        x1 = 4
    }
    public enum Direction  // направление
    {
        Horizontal,
        Vertical
    }
    internal class Model
    {
        // Массив координат своих кораблей
        public CoordStatus[,] PlayerShips = new CoordStatus[10, 10];
        // Массив координат кораблей противника
        public CoordStatus[,] EnemyShips = new CoordStatus[10, 10];
        // количество клеток кораблей противника
        public int UndiscoverCells = 20;
        // Поле статуса последнего выстрела
        public ShotStatus LastShot;
        // Поле статус ранения
        public bool WoundedStatus;
        // Поле статус первого попадания
        public bool FirstGot;
        // Поле координат последнего выстрела
        public string? LastShotCoord;


        // Конструктор. Инициализация полей модели
        public Model()
        {
            LastShot = ShotStatus.Miss;
            WoundedStatus = false;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    PlayerShips[i, j] = CoordStatus.None;
                    EnemyShips[i, j] = CoordStatus.None;
                }

            }
        }

        // Выстрел игрока. Входящий параметр - координаты выстрела в виде строки из 2х цифр
        public ShotStatus Shot(string shotCoord)
        {
            ShotStatus result = ShotStatus.Miss;
            int x, y;
            
            x = shotCoord[0] - 'A';  // Преобразование первой буквы в индекс (A=0, B=1 и т.д.)
            y = int.Parse(shotCoord.Substring(1)) - 1;  // Преобразование цифры в индекс (1=0, 2=1 и т.д.)

            if (PlayerShips[x, y] == CoordStatus.None)
            {
                result = ShotStatus.Miss;
            }
            else
            {
                result = ShotStatus.Kill;

                // Проверяем соседние клетки для определения статуса ранения
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if ((i == 0 && j == 0) || (i != 0 && j != 0)) // Пропускаем саму клетку и диагонали
                            continue;

                        int newX = x + i;
                        int newY = y + j;

                        if (newX >= 0 && newX < PlayerShips.GetLength(0) && newY >= 0 && newY < PlayerShips.GetLength(1))
                        {
                            if (PlayerShips[newX, newY] == CoordStatus.Ship)
                            {
                                result = ShotStatus.Wounded;
                            }
                        }
                    }
                }

                PlayerShips[x, y] = CoordStatus.Got;
                UndiscoverCells--;

                if (UndiscoverCells == 0)
                {
                    result = ShotStatus.EndBattle;
                }
            }
            return result;
        }

        

        //Генерация выстрела
        public string ShotGen()
        {
            int x, y;//координаты выстрела в цифровом виде
            Random rand = new Random();
            if (LastShot == ShotStatus.Kill) WoundedStatus = false;
            if ((LastShot == ShotStatus.Kill || LastShot == ShotStatus.Miss) && !WoundedStatus)
            {
                x = rand.Next(0, 9);
                y = rand.Next(0, 9);
            }
            else
            {
                x = int.Parse(LastShotCoord.Substring(0, 1));
                y = int.Parse(LastShotCoord.Substring(1));
                if (LastShot == ShotStatus.Wounded || FirstGot)
                {
                    FirstGot = true;
                    if (x != 9 && EnemyShips[x + 1, y] == CoordStatus.Got)
                    { x = x - 1; FirstGot = false; }
                    if (y != 9 && EnemyShips[x, y + 1] == CoordStatus.Got)
                    { y = y - 1; FirstGot = false; }
                    if (x != 0 && EnemyShips[x - 1, y] == CoordStatus.Got)
                    { x = x + 1; FirstGot = false; }
                    if (y != 0 && EnemyShips[x, y - 1] == CoordStatus.Got)
                    { y = y + 1; FirstGot = false; }
                    if (FirstGot)
                    {
                        int q = rand.Next(1, 4);
                        switch (q)
                        {
                            case 1: x++; break;
                            case 2: x--; break;
                            case 3: y++; break;
                            case 4: y--; break;
                        }
                    }
                }
                if (LastShot == ShotStatus.Miss && WoundedStatus)
                {
                    if (x < 8 && EnemyShips[x + 2, y] == CoordStatus.Got) x = x + 3;
                    else
                    if (y < 8 && EnemyShips[x, y + 2] == CoordStatus.Got) y = y + 3;
                    else
                    if (x > 1 && EnemyShips[x - 2, y] == CoordStatus.Got) x = x - 3;
                    else
                    if (y > 1 && EnemyShips[x, y - 2] == CoordStatus.Got) y = y - 3;
                    else
                    if (x < 7 && EnemyShips[x + 3, y] == CoordStatus.Got) x = x + 4;
                    else
                    if (y < 7 && EnemyShips[x, y + 3] == CoordStatus.Got) y = y + 4;
                    else
                    if (x > 2 && EnemyShips[x - 3, y] == CoordStatus.Got) x = x - 4;
                    else
                    if (y > 2 && EnemyShips[x, y - 3] == CoordStatus.Got) y = y - 4;
                    else
                    if (x < 9 && EnemyShips[x + 1, y] == CoordStatus.Got) x = x + 2;
                    else
                    if (y < 9 && EnemyShips[x, y + 1] == CoordStatus.Got) y = y + 2;
                    else
                    if (x > 0 && EnemyShips[x - 1, y] == CoordStatus.Got) x = x - 2;
                    else
                    if (y > 0 && EnemyShips[x, y - 1] == CoordStatus.Got) y = y - 2;
                }
            }

            string result = x.ToString() + y.ToString();
            return result;
        }
        //public string ShotGen()
        //{
        //    int x, y;
        //    Random rand = new Random();

        //    try
        //    {
        //        if (LastShot == ShotStatus.Kill)
        //            WoundedStatus = false;

        //        if ((LastShot == ShotStatus.Kill || LastShot == ShotStatus.Miss) && !WoundedStatus)
        //        {
        //            x = rand.Next(0, 9);
        //            y = rand.Next(0, 9);
        //        }
        //        else
        //        {
        //            x = int.Parse(LastShotCoord.Substring(0, 1));
        //            y = int.Parse(LastShotCoord.Substring(1));

        //            if (LastShot == ShotStatus.Wounded || FirstGot)
        //            {
        //                FirstGot = true;

        //                if (x < 9 && EnemyShips[x + 1, y] == CoordStatus.Got) x--;
        //                else if (y < 9 && EnemyShips[x, y + 1] == CoordStatus.Got) y--;
        //                else if (x > 0 && EnemyShips[x - 1, y] == CoordStatus.Got) x++;
        //                else if (y > 0 && EnemyShips[x, y - 1] == CoordStatus.Got) y++;

        //                if (FirstGot)
        //                {
        //                    int q = rand.Next(1, 5);
        //                    switch (q)
        //                    {
        //                        case 1: if (x < 9) x++; break;
        //                        case 2: if (x > 0) x--; break;
        //                        case 3: if (y < 9) y++; break;
        //                        case 4: if (y > 0) y--; break;
        //                    }
        //                }
        //            }
        //            else if (LastShot == ShotStatus.Miss && WoundedStatus)
        //            {
        //                if (x < 9 && EnemyShips[x + 1, y] == CoordStatus.Got) x += 2;
        //                else if (y < 9 && EnemyShips[x, y + 1] == CoordStatus.Got) y += 2;
        //                else if (x > 0 && EnemyShips[x - 1, y] == CoordStatus.Got) x -= 2;
        //                else if (y > 0 && EnemyShips[x, y - 1] == CoordStatus.Got) y -= 2;
        //            }
        //        }

        //        x = Math.Clamp(x, 0, 9);
        //        y = Math.Clamp(y, 0, 9);

        //        string result = x.ToString("D1") + y.ToString("D1");
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Логирование или вывод сообщения об ошибке
        //        Console.WriteLine("Error in ShotGen: " + ex.Message);
        //        return "Error";
        //    }
        //}
        public bool CheckCoord(string xy, ShipType type, Direction direction = Direction.Vertical)
        {
            bool result = true;
            return result;
        }
        //добавляет или удаляет корабль
        //ху - координаты корабля, type - тип корабля, direction - направление корабля, deleting - удаляет или добавляет
        //В случае успешной операции возвращает true       
        public bool AddDellShip(string xy, ShipType type, Direction direction = Direction.Vertical, bool deleting = false)
        {
            bool result = true;
            if (deleting || CheckCoord(xy, type, direction))
            {
                int x = int.Parse(xy.Substring(0, 1));
                int y = int.Parse(xy.Substring(1));
                CoordStatus status = new CoordStatus();
                if (deleting) status = CoordStatus.None; else status = CoordStatus.Ship;
                PlayerShips[x, y] = status;
                if (direction == Direction.Vertical)
                {
                    switch (type)
                    {
                        case ShipType.x2:
                            PlayerShips[x, y + 1] = status;
                            break;
                        case ShipType.x3:
                            PlayerShips[x, y + 1] = status;
                            PlayerShips[x, y + 2] = status;
                            break;
                        case ShipType.x4:
                            PlayerShips[x, y + 1] = status;
                            PlayerShips[x, y + 2] = status;
                            PlayerShips[x, y + 3] = status;
                            break;
                    }
                }
                else
                {
                    switch (type)
                    {
                        case ShipType.x2:
                            PlayerShips[x + 1, y] = status;
                            break;
                        case ShipType.x3:
                            PlayerShips[x + 1, y] = status;
                            PlayerShips[x + 2, y] = status;
                            break;
                        case ShipType.x4:
                            PlayerShips[x + 1, y] = status;
                            PlayerShips[x + 2, y] = status;
                            PlayerShips[x + 3, y] = status;
                            break;
                    }
                }
            }
            else result = false;
            return result;
        }
        //public bool AddDellShip(string xy, ShipType type, Direction direction = Direction.Vertical, bool deleting = false)
        //{
        //    bool result = true;
        //    int x = int.Parse(xy.Substring(0, 1));
        //    int y = int.Parse(xy.Substring(1, 1));
        //    CoordStatus status = deleting ? CoordStatus.None : CoordStatus.Ship;

        //    // Проверка границ
        //    if (direction == Direction.Vertical)
        //    {
        //        if (y + (int)type - 1 >= PlayerShips.GetLength(1)) return false; // Проверка на выход за границы
        //        for (int i = 0; i < (int)type; i++)
        //        {
        //            if (PlayerShips[x, y + i] == (deleting ? CoordStatus.Ship : CoordStatus.None))
        //                return false; // Проверка на занятость (для установки)
        //        }
        //        for (int i = 0; i < (int)type; i++)
        //        {
        //            PlayerShips[x, y + i] = status; // Обновление статуса
        //        }
        //    }
        //    else
        //    {
        //        if (x + (int)type - 1 >= PlayerShips.GetLength(0)) return false; // Проверка на выход за границы
        //        for (int i = 0; i < (int)type; i++)
        //        {
        //            if (PlayerShips[x + i, y] == (deleting ? CoordStatus.Ship : CoordStatus.None))
        //                return false; // Проверка на занятость (для установки)
        //        }
        //        for (int i = 0; i < (int)type; i++)
        //        {
        //            PlayerShips[x + i, y] = status; // Обновление статуса
        //        }
        //    }

        //    return result;
        //}

        public void DelShips()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    PlayerShips[i, j] = CoordStatus.None;
                }
            }

        }

    }
}


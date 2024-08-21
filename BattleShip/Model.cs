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
        x4,    // количество палуб
        x3,
        x2,
        x1
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
        public ShotStatus Shot(string ShotCoord)
        {
            ShotStatus result = ShotStatus.Miss;
            int x, y; // координаты выстрела в числовом виде
            x = int.Parse(ShotCoord.Substring(0, 1));
            y = int.Parse(ShotCoord.Substring(1));
            if (PlayerShips[x, y] == CoordStatus.None)
            { result = ShotStatus.Miss; }
            else
            {
                result = ShotStatus.Kill;
                if ((x != 9 && PlayerShips[x + 1, y] == CoordStatus.Ship) ||
                    (y != 9 && PlayerShips[x, y + 1] == CoordStatus.Ship) ||
                    (x != 0 && PlayerShips[x - 1, y] == CoordStatus.Ship) ||
                    (y != 0 && PlayerShips[x, y - 1] == CoordStatus.Ship) ||
                    (x < 8 && PlayerShips[x + 2, y] == CoordStatus.Ship) ||
                    (y < 8 && PlayerShips[x, y + 2] == CoordStatus.Ship) ||
                    (x > 1 && PlayerShips[x - 2, y] == CoordStatus.Ship) ||
                    (y > 1 && PlayerShips[x, y - 2] == CoordStatus.Ship) ||
                    (x < 7 && PlayerShips[x + 3, y] == CoordStatus.Ship) ||
                    (y < 7 && PlayerShips[x, y + 3] == CoordStatus.Ship) ||
                    (x > 2 && PlayerShips[x - 3, y] == CoordStatus.Ship) ||
                    (y > 2 && PlayerShips[x, y - 3] == CoordStatus.Ship))
                    result = ShotStatus.Wounded;
                PlayerShips[x, y] = CoordStatus.Got;
                UndiscoverCells--;
                if (UndiscoverCells == 0) { result = ShotStatus.EndBattle; }
            }
            return result;
        }

        //Генерация выстрела
        //public string ShotGen()
        //{            
        //    int x, y; // координаты выстрела в цифровом виде
        //    Random rand = new Random();
        //    if (LastShot == ShotStatus.Kill) WoundedStatus = false;
        //    if ((LastShot == ShotStatus.Kill || LastShot == ShotStatus.Miss) && !WoundedStatus)
        //    {
        //        x = rand.Next(0, 9);
        //        y = rand.Next(0, 9);
        //    }
        //    else
        //    {
        //        x = int.Parse(LastShotCoord.Substring(0, 1));
        //        y = int.Parse(LastShotCoord.Substring(1));
        //        if (LastShot == ShotStatus.Wounded || FirstGot)
        //        {
        //            FirstGot = true;
        //            if (x != 9 && EnemyShips[x + 1, y] == CoordStatus.Got)
        //            { x = x - 1; FirstGot = false; }
        //            if (y != 9 && EnemyShips[x, y + 1] == CoordStatus.Got)
        //            { y = y - 1; FirstGot = false; }
        //            if (x != 0 && EnemyShips[x - 1, y] == CoordStatus.Got)
        //            { x = x + 1; FirstGot = false; }
        //            if (y != 0 && EnemyShips[x, y - 1] == CoordStatus.Got)
        //            { y = y + 1; FirstGot = false; }
        //            if (FirstGot)
        //            {
        //                int q = rand.Next(1, 4);
        //                switch (q)
        //                {
        //                    case 1: x++; break;
        //                    case 2: x--; break;
        //                    case 3: y++; break;
        //                    case 4: y--; break;
        //                }
        //            }

        //        }
        //        if(LastShot == ShotStatus.Miss && WoundedStatus)
        //        {
        //            if (x < 9 && EnemyShips[x + 1, y] == CoordStatus.Got) x = x + 2;
        //            if (x < 9 && EnemyShips[x, y + 1] == CoordStatus.Got) y = y + 2;
        //            if (x < 0 && EnemyShips[x - 1, y] == CoordStatus.Got) x = x - 2;
        //            if (x < 0 && EnemyShips[x, y - 1] == CoordStatus.Got) y = y - 2;
        //            if (x < 8 && EnemyShips[x + 2, y] == CoordStatus.Got) x = x + 3;
        //            if (x < 8 && EnemyShips[x, y + 2] == CoordStatus.Got) y = y + 3;
        //            if (x < 1 && EnemyShips[x - 2, y] == CoordStatus.Got) x = x - 3;
        //            if (x < 1 && EnemyShips[x, y - 2] == CoordStatus.Got) y = y - 3;
        //            if (x < 7 && EnemyShips[x + 3, y] == CoordStatus.Got) x = x + 4;
        //            if (x < 7 && EnemyShips[x, y + 3] == CoordStatus.Got) y = y + 4;
        //            if (x < 2 && EnemyShips[x - 3, y] == CoordStatus.Got) x = x - 4;
        //            if (x < 2 && EnemyShips[x, y - 3] == CoordStatus.Got) y = y - 4;
        //        }
        //    }            
        //    string result = x.ToString() + y.ToString();
        //    return result;
        //}
        public string ShotGen()
        {
            int x, y;
            Random rand = new Random();

            try
            {
                if (LastShot == ShotStatus.Kill)
                    WoundedStatus = false;

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

                        if (x < 9 && EnemyShips[x + 1, y] == CoordStatus.Got) x--;
                        else if (y < 9 && EnemyShips[x, y + 1] == CoordStatus.Got) y--;
                        else if (x > 0 && EnemyShips[x - 1, y] == CoordStatus.Got) x++;
                        else if (y > 0 && EnemyShips[x, y - 1] == CoordStatus.Got) y++;

                        if (FirstGot)
                        {
                            int q = rand.Next(1, 5);
                            switch (q)
                            {
                                case 1: if (x < 9) x++; break;
                                case 2: if (x > 0) x--; break;
                                case 3: if (y < 9) y++; break;
                                case 4: if (y > 0) y--; break;
                            }
                        }
                    }
                    else if (LastShot == ShotStatus.Miss && WoundedStatus)
                    {
                        if (x < 9 && EnemyShips[x + 1, y] == CoordStatus.Got) x += 2;
                        else if (y < 9 && EnemyShips[x, y + 1] == CoordStatus.Got) y += 2;
                        else if (x > 0 && EnemyShips[x - 1, y] == CoordStatus.Got) x -= 2;
                        else if (y > 0 && EnemyShips[x, y - 1] == CoordStatus.Got) y -= 2;
                    }
                }

                x = Math.Clamp(x, 0, 9);
                y = Math.Clamp(y, 0, 9);

                string result = x.ToString("D1") + y.ToString("D1");
                return result;
            }
            catch (Exception ex)
            {
                // Логирование или вывод сообщения об ошибке
                Console.WriteLine("Error in ShotGen: " + ex.Message);
                return "Error";
            }
        }
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
                if(deleting)
                {
                    status = CoordStatus.None;
                }
                else
                {
                    status = CoordStatus.Ship;
                }
                PlayerShips[x, y] = CoordStatus.Ship;
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


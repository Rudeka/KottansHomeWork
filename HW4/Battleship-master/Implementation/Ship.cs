using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Implementation
{
    public class Ship
    {
        public Ship()
        {
        }

        public Ship(int xCoor, int yCoor)
        {
            X = xCoor;
            Y = yCoor;
           
        }
        public Ship(int xCoor, int yCoor, Direction directon, int size)
        {
            X = xCoor;
            Y = yCoor;
            Size = size;
            Direction = directon;
        }
        public Ship(int xCoor, int yCoor, int size, Direction directon)
        {
            X = xCoor;
            Y = yCoor;
            Size = size;
            Direction = directon;
        }

        public int X { get; private set; }
        public int Y { get; }
        public int Size { get; }
        public Direction Direction { get; }

        public static Ship Parse(string notation)
        {
            var length = 1;
            var direction = Direction.Horizontal;

            var match = Regex.Match(notation, @"(?<coorX>[A-Ja-j]{1})(?<coorY>\d+)(?<xSymbol>x)?(?<length>\d*)?(?<direction>[-|])?");

            if (!match.Success)
                throw new NotAShipException();
            XCoordinates xCoordinates;
            Enum.TryParse(match.Groups["coorX"].Value, out xCoordinates);
            var coorX = (int)xCoordinates;

            var checkCoorY = int.Parse(match.Groups["coorY"].Value);
            if (checkCoorY > 10)
            {
                throw new NotAShipException();
            }
            var coorY = checkCoorY;

            if (!string.IsNullOrEmpty(match.Groups["length"].Value))
            {
                var checkLength = int.Parse(match.Groups["length"].Value);
                if (checkLength > 4)
                {
                    throw new NotAShipException();
                }
                length = checkLength;
            }

            var checkDirection = match.Groups["direction"].Value;
            if (!string.IsNullOrEmpty(checkDirection))
            {
                if (checkDirection == "|")
                {
                    direction = Direction.Vertical;
                }
            }

            switch (length)
            {
                case 2:
                    return new Cruiser(coorX, coorY, length, direction);
                case 3:
                    return new Submarine(coorX, coorY, length, direction);
                case 4:
                    return new AircraftCarrier(coorX, coorY, length, direction);
                default:
                    return new PatrolBoat(coorX, coorY, length, direction);
            }
        }

        public static bool TryParse(string notation, out Ship pos)
        {
            pos = default(Ship);
            try
            {
                pos = (Ship)Parse(notation);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool FitsInSquare(int squareHeight, int squareWidth, 
            Direction direction = Direction.Horizontal)
        {

            int sizeX, sizeY;
            var square = squareWidth * squareHeight;

            if (Direction == Direction.Vertical)
            {
                sizeY = Y * Size;
                sizeX = X;
            }
            else
            {
                sizeX = X * Size;
                sizeY = Y;
            }

            return squareHeight >= Y
                   && squareWidth >= X
                   && squareHeight >= sizeY
                   && squareWidth >= sizeX
                   && square >= sizeY
                   && square >= sizeX;

        }

        public bool OverlapsWith(Ship otherShip)
        {
            var shipLastX = X + Size - 1;
            var otherShipLastX = otherShip.X + otherShip.Size - 1;
            var shipAllX = new List<int>();
            var otherShipAllX = new List<int>();

            var shipLastY = Y;
            var otherShipLastY = otherShip.Y;
            var shipAllY = new List<int> { Y };
            var otherShipAllY = new List<int> { otherShip.Y };

          
            if (Direction == Direction.Vertical)
            {
                shipLastX = X;
                shipLastY = Y + Size - 1;
                for (var i = Y; i < shipLastY; i++)
                {
                    shipAllY.Add(i);
                }
                
            }
            

            if (otherShip.Direction == Direction.Vertical)
            {
                otherShipLastX = otherShip.X;
                otherShipLastY = otherShip.Y + otherShip.Size - 1;
                for (var i = Y; i < otherShipLastY; i++)
                {
                    otherShipAllY.Add(i);
                }

            }

            for (var i = X; i <= shipLastX; i++)
            {
                shipAllX.Add(i);
            }

            for (var i = otherShip.X; i <= otherShipLastX; i++)
            {
                otherShipAllX.Add(i);
            }

            if (X == otherShip.X && Y == otherShip.Y) return true;

            if (otherShipAllX.Any(t => otherShipAllY.Any(t1 => shipAllX.Any(a => a == t)
                                                               && shipAllY.Any(a => a == t1))))
            {
                return true;
            }

            foreach (var t in otherShipAllX)
            {
                foreach (var t1 in otherShipAllY)
                {
                    if (X < otherShip.X)
                    {
                        if (Y < otherShip.Y)
                        {
                            if (shipAllX.Any(a => a == t - 1)
                                && shipAllY.Any(a => a == t1 - 1))
                            {
                                return true;
                            }
                        }
                        if (Y > otherShip.Y)
                        {
                            if (shipAllX.Any(a => a == t - 1)
                                && shipAllY.Any(a => a == t1 + 1))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (shipAllX.Any(a => a == t - 1)
                                && shipAllY.Any(a => a == t1))
                            {
                                return true;
                            }
                        }
                    }

                    if (X > otherShip.X)
                    {
                        if (Y > otherShip.Y)
                        {
                            if (shipAllX.Any(a => a == t + 1)
                                && shipAllY.Any(a => a == t1 + 1))
                            {
                                return true;
                            }
                        }
                        if (Y < otherShip.Y)
                        {
                            if (shipAllX.Any(a => a == t + 1)
                                && shipAllY.Any(a => a == t1 - 1))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (shipAllX.Any(a => a == t + 1)
                                && shipAllY.Any(a => a == t1))
                            {
                                return true;
                            }
                        }
                    }

                    if (X != otherShip.X) continue;
                    if (Y > otherShip.Y)
                    {
                        if (shipAllX.Any(a => a == t)
                            && shipAllY.Any(a => a == t1 + 1))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (shipAllX.Any(a => a == t)
                            && shipAllY.Any(a => a == t1 - 1))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
}
}
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
            var shipLastX = X + Size - 1;

            var shipAllX = new List<int>();
            var shipAllY = new List<int> { Y };

            if (Direction == Direction.Vertical)
            {
                shipLastX = X;
                var shipLastY = Y + Size - 1;
                for (var i = Y + 1; i < shipLastY; i++)
                {
                    shipAllY.Add(i);
                }

            }

            for (var i = X; i <= shipLastX; i++)
            {
                shipAllX.Add(i);
            }

            return shipAllX.All(x => x <= squareWidth) 
                && shipAllY.All(y => y <= squareHeight);
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

            var xCoordinatesForGap = new List<int>();
            var yCoordinatesForGap = new List<int>();



            if (Direction == Direction.Vertical)
            {
                shipLastX = X;
                shipLastY = Y + Size - 1;
                for (var i = Y+1; i < shipLastY; i++)
                {
                    shipAllY.Add(i);
                }
                
            }
            

            if (otherShip.Direction == Direction.Vertical)
            {
                otherShipLastX = otherShip.X;
                otherShipLastY = otherShip.Y + otherShip.Size - 1;
                for (var i = Y+1; i < otherShipLastY; i++)
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

            foreach (var shipX in shipAllX)
            {
                xCoordinatesForGap.Add(shipX);
                xCoordinatesForGap.Add(shipX + 1);
                xCoordinatesForGap.Add(shipX - 1);
            }

            foreach (var shipY in shipAllY)
            {
                yCoordinatesForGap.Add(shipY);
                yCoordinatesForGap.Add(shipY + 1);
                yCoordinatesForGap.Add(shipY - 1);
            }

            if (X == otherShip.X && Y == otherShip.Y) return true;

            if (otherShipAllX.Any(t => otherShipAllY.Any(t1 => shipAllX.Any(a => a == t)
                                                               && shipAllY.Any(a => a == t1))))
            {
                return true;
            }

            return otherShipAllX.Any(t => otherShipAllY.Any(t1 => xCoordinatesForGap.Any(a => a == t)
                                                                  && yCoordinatesForGap.Any(a => a == t1)));

        }
}
}
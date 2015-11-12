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
        public Ship(int xCoor, int yCoor, int length, Direction directon)
        {
            X = xCoor;
            Y = yCoor;
            Length = length;
            Direction = directon;
        }

        public int X { get; private set; }
        public int Y { get; }
        public int Length { get; }
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

        public bool FitsInSquare(int squareHeight, int squareWidth)
        {

            int sizeX, sizeY;
            var square = squareWidth * squareHeight;

            if (Direction == Direction.Vertical)
            {
                sizeY = Y * Length;
                sizeX = X;
            }
            else
            {
                sizeX = X * Length;
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
            var shipLastX = X + Length - 1;
            var otherShipLastX = otherShip.X + otherShip.Length - 1;
            var shipAllX = new List<int>();
            var otherShipAllX = new List<int>();

            var shipLastY = Y;
            var otherShipLastY = otherShip.Y;
            var shipAllY = new List<int> { Y };
            var otherShipAllY = new List<int> { otherShip.Y };

            //var thisSizeX = X + Length - 1;
            //var thisSizeY = Y;
            //var otherSizeX = otherShip.X + otherShip.Length - 1;
            //var otherSizeY = otherShip.Y;
            //var checkOverlappingX = otherSizeX + 1;
            //var checkOverlappingY = otherSizeY + 1;
            //var checkOverlappingXY = thisSizeX+1 * thisSizeY+1;

            //var directionCheck = Direction.ToString();
            if (Direction == Direction.Vertical)
            {
                shipLastX = X;
                shipLastY = Y + Length - 1;
                for (var i = Y; i < shipLastY; i++)
                {
                    shipAllY.Add(i);
                }
                //thisSizeY = Y * Length;
                //thisSizeX = X;
            }
            //if (otherShip.Direction == Direction.Vertical)
            //{
            //    otherSizeY = otherShip.Y * otherShip.Length;
            //    otherSizeX = otherShip.X;
            //}

            if (otherShip.Direction == Direction.Vertical)
            {
                otherShipLastX = otherShip.X;
                otherShipLastY = otherShip.Y + otherShip.Length - 1;
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
            //thisSizeY = Y * Length;
            //thisSizeX = X;

            //if (Direction == Direction.Horizontal)
            //{
            //    thisSizeX = X * Length;
            //    thisSizeY = Y;
            //}
            //else
            //{
            //    otherSizeX = X * Length;
            //    otherSizeY = Y;
            //}
            //if (ReferenceEquals(null, otherShip)) return false;
            //if (ReferenceEquals(this, otherShip)) return true;

            //if (X == otherShip.X && Y == otherShip.Y) return true;

            //if (thisSizeX == otherSizeY && thisSizeY == otherSizeX) return true;
            //if (thisSizeX == otherSizeX && thisSizeY == otherSizeY) return true;

            //if (X >= otherShip.X && Y >= otherShip.Y)
            //{
            //    if (X == otherSizeX && Y > otherSizeY)
            //    {
            //        return otherSizeY + 1 == Y;
            //    }

            //    if (X > otherSizeX && Y == otherSizeY)
            //    {
            //        return otherSizeX + 1 == X;
            //    }
            //    if (X > otherSizeX && Y > otherSizeY)
            //    {
            //        return (otherSizeX + 1 == X && otherSizeY + 1 == Y);
            //    }
            //    return X == otherShip.X && Y == otherShip.Y;

            //}

            //return thisSizeX + 1 == otherShip.X || thisSizeY + 1 == otherShip.Y;

            if (X == otherShip.X && Y == otherShip.Y) return true;

            for (var i = 0; i < otherShipAllX.Count; i++)
            {
                for (var j = 0; j < otherShipAllY.Count; j++)
                {
                    if (shipAllX.Any(a => a == otherShipAllX[i])
                        && shipAllY.Any(a => a == otherShipAllY[j]))
                    {
                        return true;
                    }
                }
            }

            for (var i = 0; i < otherShipAllX.Count; i++)
            {
                for (var j = 0; j < otherShipAllY.Count; j++)
                {
                    if (X < otherShip.X)
                    {
                        if (Y < otherShip.Y)
                        {
                            if (shipAllX.Any(a => a == otherShipAllX[i] - 1)
                                && shipAllY.Any(a => a == otherShipAllY[j] - 1))
                            {
                                return true;
                            }
                        }
                        if (Y > otherShip.Y)
                        {
                            if (shipAllX.Any(a => a == otherShipAllX[i] - 1)
                                && shipAllY.Any(a => a == otherShipAllY[j] + 1))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (shipAllX.Any(a => a == otherShipAllX[i] - 1)
                                && shipAllY.Any(a => a == otherShipAllY[j]))
                            {
                                return true;
                            }
                        }
                    }

                    if (X > otherShip.X)
                    {
                        if (Y > otherShip.Y)
                        {
                            if (shipAllX.Any(a => a == otherShipAllX[i] + 1)
                                && shipAllY.Any(a => a == otherShipAllY[j] + 1))
                            {
                                return true;
                            }
                        }
                        if (Y < otherShip.Y)
                        {
                            if (shipAllX.Any(a => a == otherShipAllX[i] + 1)
                                && shipAllY.Any(a => a == otherShipAllY[j] - 1))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (shipAllX.Any(a => a == otherShipAllX[i] + 1)
                                && shipAllY.Any(a => a == otherShipAllY[j]))
                            {
                                return true;
                            }
                        }
                    }

                    if (X == otherShip.X)
                    {
                        if (Y > otherShip.Y)
                        {
                            if (shipAllX.Any(a => a == otherShipAllX[i])
                                && shipAllY.Any(a => a == otherShipAllY[j] + 1))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (shipAllX.Any(a => a == otherShipAllX[i])
                                && shipAllY.Any(a => a == otherShipAllY[j] - 1))
                            {
                                return true;
                            }
                        }
                    }
                }

            }
        






            //if (X >= otherShip.X && Y >= otherShip.Y)
            //{
            //    for (var i = 0; i < otherShipAllX.Count; i++)
            //    {
            //        for (var j = 0; j < otherShipAllY.Count; j++)
            //        {
            //            if (shipAllX.Any(a => a == otherShipAllX[i])
            //                && shipAllY.Any(a => a == otherShipAllY[j]))
            //            {
            //                return true;
            //            }

            //            if (shipAllX.Any(a => a == otherShipAllX[i] + 1)
            //                || shipAllY.Any(a => a == otherShipAllY[j] + 1))
            //            {
            //                return true;
            //            };
            //        }
            //    }
            //    return false;
            //}

            //if (X <= otherShip.X && Y <= otherShip.Y)
            //{
            //    //bool overlapXY;

            //    //bool gapXY;

            //    for (var i = 0; i < shipAllX.Count; i++)
            //    {
            //        for (var j = 0; j < shipAllY.Count; j++)
            //        {
            //            if (otherShipAllX.Any(a => a == shipAllX[i])
            //                && otherShipAllY.Any(a => a == shipAllY[j]))
            //            {
            //                return true;
            //            }
            //            if (otherShipAllX.Any(a => a == shipAllX[i] + 1)
            //                || otherShipAllY.Any(a => a == shipAllY[j] + 1))
            //            {
            //                return true;
            //            }
            //        }
            //    }
            //    return false;
            //}

            return false;

        }
}
}
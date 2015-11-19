using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class Board
    {
        private readonly List<Ship> shipsOnBoard = new List<Ship>();
        
        public void Add(object shipType)
        {
            Ship ship;
            if (shipType is string)
            {
                ship = Ship.Parse(shipType.ToString());
            }
            else
            {
                ship = (Ship) shipType;
            }

            shipsOnBoard.Add(ship);

            var total = shipsOnBoard.Count;
            for (var i = 0; i < total-1; i++)
            {
                if (ship.OverlapsWith(shipsOnBoard[i]))
                {
                    throw new ShipOverlapException($"Ship {(XCoordinates)ship.X}{ship.Y}x{ship.Size}{ship.Direction} overlaps with " +
                                                   $"{(XCoordinates)shipsOnBoard[i].X}{shipsOnBoard[i].Y}x{shipsOnBoard[i].Size}{shipsOnBoard[i].Direction}");
                };
            }

            if (!ShipOnBoard())
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public List<Ship> GetAll()
        {
            return shipsOnBoard;
        }

        public void Validate()
        {
            var patrolBoats = shipsOnBoard.Count(ship => ship.Size == 1);
            var cruisers = shipsOnBoard.Count(ship => ship.Size == 2);
            var submarines = shipsOnBoard.Count(ship => ship.Size == 3);
            var aircraftCarriers = shipsOnBoard.Count(ship => ship.Size == 4);
            var message = "There is not sufficient count of ships. We need: ";

            if (patrolBoats == 4 && cruisers == 3 && submarines == 2 && aircraftCarriers == 1) return;

            if (patrolBoats != 4)
            {
                message += $"PatrolBoat ({4-patrolBoats}) ";
            }

            if (cruisers != 3)
            {
                message += $"Cruiser ({3 - cruisers}) ";
            }

            if (submarines != 2)
            {
                message += $"Submarine ({2 - submarines}) ";
            }

            if (aircraftCarriers != 1)
            {
                message += $"AircraftCarrier ({1 - aircraftCarriers})";
            }

            throw new BoardIsNotReadyException(message);
        }

       public bool ShipOnBoard()
        {
            if (shipsOnBoard.Any(a => a.X < 0 || a.Y < 0 || a.X > 10 || a.Y > 10))
            {
                return false;
            }
            if (shipsOnBoard.Any(a => a.Direction == Direction.Horizontal && a.X + a.Size - 1 > 10))
            {
                return false;
            }
            return !shipsOnBoard.Any(a => a.Direction == Direction.Vertical && a.Y + a.Size - 1 > 10);
        }
    }
}

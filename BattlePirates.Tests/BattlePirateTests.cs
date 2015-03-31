using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattlePirates_Group2;
using System.Drawing;

namespace BattlePirates.Tests {
    [TestClass]
    public class BattlePirateTests {


        [TestMethod]
        public void CreateShip() {
            BaseShip board = new BrigShip();
            Point ha = new Point(5, 5);
        }

        [TestMethod]
        public void checkForShipTest() {
            BaseShip ship = new BrigShip();
            //Point testPoint = new Point(5,5);

            Point[] location = new Point[3];
            location[0] = new Point(5, 5);
            location[1] = new Point(6, 5);
            location[2] = new Point(7, 5);

            ship.setLocation(location, false);

            Point strike = new Point(5, 5);

            Assert.AreEqual(true, ship.checkForShip(strike));

        }

        [TestMethod]
        public void checkForHitTest() {
            BaseShip ship = new BrigShip();
            //Point testPoint = new Point(5,5);

            Point[] location = new Point[3];
            location[0] = new Point(5, 5);
            location[1] = new Point(6, 5);
            location[2] = new Point(7, 5);

            ship.setLocation(location, false);

            Point strike = new Point(5, 5);

            Assert.AreEqual(true, ship.checkForHit(strike));

        }

        [TestMethod]
        public void checkForVertical() {
            BaseShip ship = new BrigShip();
            //Point testPoint = new Point(5,5);

            Point[] location = new Point[3];
            location[0] = new Point(5, 5);
            location[1] = new Point(6, 5);
            location[2] = new Point(7, 5);

            ship.setLocation(location, false);

            Assert.AreEqual(false, ship.isVertical());

        }

        [TestMethod]
        public void checkForSunk() {
            BaseShip ship = new BrigShip();

            Point[] location = new Point[3];
            location[0] = new Point(5, 5);
            location[1] = new Point(6, 5);
            location[2] = new Point(7, 5);

            ship.setLocation(location, false);

            ship.checkForHit(new Point(5, 5));
            ship.checkForHit(new Point(6, 5));
            ship.checkForHit(new Point(7, 5));

            Assert.AreEqual(true, ship.isSunk());

        }


    }
}

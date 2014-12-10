namespace UnitTestProject1

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type UnitTest() =
    [<TestMethod>]
    member x.HelloFsharp () =
        let testVal = 1
        Assert.AreEqual(1, testVal)

    [<TestMethod>]
    member y.startXXX () =
       let start = Tutorial.Rover.position(0, 0, Tutorial.Rover.North)
       Assert.AreEqual(0,start.x)
       Assert.AreEqual(0,start.y)
       Assert.AreEqual(Tutorial.Rover.North,start.direction)
       
    [<TestMethod>]
    member y.moveForward () =
       let start = Tutorial.Rover.position(0, 0, Tutorial.Rover.North)
       let newPosition = Tutorial.Rover.applyCommand(start, Tutorial.Rover.Command.Forward)
       Assert.AreEqual(0,newPosition.x)
       Assert.AreEqual(1,newPosition.y)
       Assert.AreEqual(Tutorial.Rover.North,newPosition.direction)

    [<TestMethod>]
    member y.moveSouth () =
       let start = Tutorial.Rover.position(3, 4, Tutorial.Rover.South)
       let newPosition = Tutorial.Rover.applyCommand(start, Tutorial.Rover.Command.Forward)
       Assert.AreEqual(3,newPosition.x)
       Assert.AreEqual(3,newPosition.y)
       Assert.AreEqual(Tutorial.Rover.South,newPosition.direction)

    [<TestMethod>]
    member y.moveEast () =
       let start = Tutorial.Rover.position(3, 3, Tutorial.Rover.East)
       let newPosition = Tutorial.Rover.applyCommand(start, Tutorial.Rover.Command.Forward)
       Assert.AreEqual(4,newPosition.x)
       Assert.AreEqual(3,newPosition.y)
       Assert.AreEqual(Tutorial.Rover.East,newPosition.direction)

    [<TestMethod>]
    member y.turnLeft () =
       let start = Tutorial.Rover.position(5,5, Tutorial.Rover.East)
       let newPosition = Tutorial.Rover.applyCommand(start, Tutorial.Rover.Command.TurnLeft)
       Assert.AreEqual(5, newPosition.x)
       Assert.AreEqual(5, newPosition.y)
       Assert.AreEqual(Tutorial.Rover.North, newPosition.direction)


      
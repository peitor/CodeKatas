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
    member y.North_MoveForward () =
       let start = Tutorial.Rover.position(0, 0, Tutorial.Rover.North)
       let newPosition = Tutorial.Rover.applyCommand(start, Tutorial.Rover.Command.Forward)
       Assert.AreEqual(0,newPosition.x)
       Assert.AreEqual(1,newPosition.y)
       Assert.AreEqual(Tutorial.Rover.North,newPosition.direction) 
       
    [<TestMethod>]
    member y.North_MoveBackward () =
       let start = Tutorial.Rover.position(1, 1, Tutorial.Rover.North)
       let newPosition = Tutorial.Rover.applyCommand(start, Tutorial.Rover.Command.Backward)
       Assert.AreEqual(1,newPosition.x)
       Assert.AreEqual(0,newPosition.y)
       Assert.AreEqual(Tutorial.Rover.North,newPosition.direction)

    [<TestMethod>]
    member y.South_moveForward () =
       let start = Tutorial.Rover.position(3, 4, Tutorial.Rover.South)
       let newPosition = Tutorial.Rover.applyCommand(start, Tutorial.Rover.Command.Forward)
       Assert.AreEqual(3,newPosition.x)
       Assert.AreEqual(3,newPosition.y)
       Assert.AreEqual(Tutorial.Rover.South,newPosition.direction)

    [<TestMethod>]
    member y.East_MoveForward () =
       let start = Tutorial.Rover.position(3, 3, Tutorial.Rover.East)
       let newPosition = Tutorial.Rover.applyCommand(start, Tutorial.Rover.Command.Forward)
       Assert.AreEqual(4,newPosition.x)
       Assert.AreEqual(3,newPosition.y)
       Assert.AreEqual(Tutorial.Rover.East,newPosition.direction)

    [<TestMethod>]
    member y.East_MoveBackward () =
       let start = Tutorial.Rover.position(1, 1, Tutorial.Rover.East)
       let newPosition = Tutorial.Rover.applyCommand(start, Tutorial.Rover.Command.Backward)
       Assert.AreEqual(0,newPosition.x)
       Assert.AreEqual(1,newPosition.y)
       Assert.AreEqual(Tutorial.Rover.East,newPosition.direction)

    [<TestMethod>]
    member y.West_MoveForward () =
       let start = Tutorial.Rover.position(1, 1, Tutorial.Rover.West)
       let newPosition = Tutorial.Rover.applyCommand(start, Tutorial.Rover.Command.Forward)
       Assert.AreEqual(0,newPosition.x)
       Assert.AreEqual(1,newPosition.y)
       Assert.AreEqual(Tutorial.Rover.West,newPosition.direction)

    [<TestMethod>]
    member y.East_TurnLeft () =
       let start = Tutorial.Rover.position(1,1, Tutorial.Rover.East)
       let newPosition = Tutorial.Rover.applyCommand(start, Tutorial.Rover.Command.TurnLeft)
       Assert.AreEqual(1, newPosition.x)
       Assert.AreEqual(1, newPosition.y)
       Assert.AreEqual(Tutorial.Rover.North, newPosition.direction)

    [<TestMethod>]
    member y.East_TurnRight () =
       let start = Tutorial.Rover.position(1,1, Tutorial.Rover.East)
       let newPosition = Tutorial.Rover.applyCommand(start, Tutorial.Rover.Command.TurnRight)
       Assert.AreEqual(1, newPosition.x)
       Assert.AreEqual(1, newPosition.y)
       Assert.AreEqual(Tutorial.Rover.South, newPosition.direction)

    [<TestMethod>]
    member y.MoveRoverByCommandListWithLeftTurn () =
       let start = Tutorial.Rover.position(1,1, Tutorial.Rover.East)

       let newPosition = Tutorial.Rover.move(start, [Tutorial.Rover.Command.Forward; Tutorial.Rover.Command.TurnLeft;Tutorial.Rover.Command.Forward], [])
       Assert.AreEqual(2, newPosition.x)
       Assert.AreEqual(2, newPosition.y)
       Assert.AreEqual(Tutorial.Rover.North, newPosition.direction)
              

    [<TestMethod>]
    member y.MoveRoverByCommandListWithRightTurn () =
       let start = Tutorial.Rover.position(1,1, Tutorial.Rover.East)

       let newPosition = Tutorial.Rover.move(start, [Tutorial.Rover.Command.Forward; Tutorial.Rover.Command.TurnRight;Tutorial.Rover.Command.Forward], [])
       Assert.AreEqual(2, newPosition.x)
       Assert.AreEqual(0, newPosition.y)
       Assert.AreEqual(Tutorial.Rover.South, newPosition.direction)
       
    [<TestMethod>]
    member y.MoveRoverByCharacterList () =
       let start = Tutorial.Rover.position(1,1, Tutorial.Rover.East)

       let newPosition = Tutorial.Rover.move2(start, ["F";"R";"F"], [])
       Assert.AreEqual(2, newPosition.x)
       Assert.AreEqual(0, newPosition.y)
       Assert.AreEqual(Tutorial.Rover.South, newPosition.direction)

    [<TestMethod>]
    member y.MoveNorth_WrapAround () =
       let start = Tutorial.Rover.position(99,99, Tutorial.Rover.North)

       let newPosition = Tutorial.Rover.move2(start, ["F"], [])
       Assert.AreEqual(99, newPosition.x)
       Assert.AreEqual(0, newPosition.y)
       
    [<TestMethod>]
    member y.MoveEast_WrapAround () =
       let start = Tutorial.Rover.position(99,99, Tutorial.Rover.East)

       let newPosition = Tutorial.Rover.move2(start, ["F"], [])
       Assert.AreEqual(0, newPosition.x)
       Assert.AreEqual(99, newPosition.y)
       
    [<TestMethod>]
    member y.MoveWest_WrapAround () =
       let start = Tutorial.Rover.position(0,0, Tutorial.Rover.West)

       let newPosition = Tutorial.Rover.move2(start, ["F"], [])
       Assert.AreEqual(99, newPosition.x)
       Assert.AreEqual(0, newPosition.y)

    [<TestMethod>]
    member y.MoveRoverUntilObstacleEncountered () =
       let start = Tutorial.Rover.position(1,1, Tutorial.Rover.East)

       let newPosition = Tutorial.Rover.move2(start, ["F"; "L"; "F"], [Tutorial.Rover.obstacle(2,2)])
       Assert.AreEqual(2, newPosition.x)
       Assert.AreEqual(1, newPosition.y)
       Assert.AreEqual(Tutorial.Rover.North, newPosition.direction)
              



      
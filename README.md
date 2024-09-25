# acme-core-net-api

In this repository, we are going to see practical example for **Dummy**, **Stub**, **Spy**, **Mock**, and **Fake** in unit test for C#.

> [!NOTE]
> If you are using Java, you could head to [the Java repository](https://github.com/ivan-akira/acme-core-api).

According to Martin Fowler, there are various kinds of test double that Gerard Meszaros lists:
- **Dummy** objects are passed around but never actually used. Usually they are just used to fill parameter lists.
- **Fake** objects actually have working implementations, but usually take some shortcut which makes them not suitable for production (an InMemoryTestDatabase is a good example).
- **Stubs** provide canned answers to calls made during the test, usually not responding at all to anything outside what's programmed in for the test.
- **Spies** are stubs that also record some information based on how they were called. One form of this might be an email service that records how many messages it was sent.
- **Mocks** are pre-programmed with expectations which form a specification of the calls they are expected to receive. They can throw an exception if they receive a call they don't expect and are checked during verification to ensure they got all the calls they were expecting[^1].

## Dummy

Example of **Dummy** class [🔗](https://github.com/ivan-akira/acme-core-net-api/blob/main/Acme/Acme.UnitTest/Part_A_Dummy/MoveRobotTransactionActionTest.cs#L35-L40).
```csharp
        private class MovementStrategyDummy : IMovementStrategy // <- this is dummy
        {
            public void Move(long currentPosition, long nextPosition)
            {
            }
        }
```

Its usage in unit test [🔗](https://github.com/ivan-akira/acme-core-net-api/blob/main/Acme/Acme.UnitTest/Part_A_Dummy/MoveRobotTransactionActionTest.cs#L16-L33).
```csharp
        [Fact]
        public void Move_PositiveStep_ReturnCorrectPosition()
        {
            // arrange
            var initialPosition = 10L;
            var step = 3L;
            var expectedPosition = 13L;

            var movementStrategy = new MovementStrategyDummy();

            moveRobotTransactionAction.SetInitialPosition(initialPosition);

            // act
            var result = moveRobotTransactionAction.Move(step, movementStrategy);

            // assert
            Assert.Equal(expectedPosition, result);
        }
```

See the whole **Dummy** example on [`MoveRobotTransactionActionTest.cs`](https://github.com/ivan-akira/acme-core-net-api/blob/main/Acme/Acme.UnitTest/Part_A_Dummy/MoveRobotTransactionActionTest.cs).

## Stub

Example of **Stub** classes [🔗](https://github.com/ivan-akira/acme-core-net-api/blob/main/Acme/Acme.UnitTest/Part_B_Stub/CalculatorTransactionActionTest.cs#L31-L39).
```csharp
        private class OneComplexNumberStub : IComplexNumber // <- this is stub
        {
            public long Number => 1L;
        }

        private class ThreeComplexNumberStub : IComplexNumber // <- this is stub
        {
            public long Number => 3L;
        }
```

Its usage in unit test [🔗](https://github.com/ivan-akira/acme-core-net-api/blob/main/Acme/Acme.UnitTest/Part_B_Stub/CalculatorTransactionActionTest.cs#L16-L29).
```csharp
        [Fact]
        public void Add_PositiveComplexNumber_ReturnPositiveComplexNumber()
        {
            // arrange
            var number1 = new OneComplexNumberStub();
            var number2 = new ThreeComplexNumberStub();
            var expectedResult = 4L;

            // act
            var result = calculatorTransactionAction.Add(number1, number2);

            // assert
            Assert.Equal(expectedResult, result.Number);
        }
```

See the whole **Stub** examples on [`CalculatorTransactionActionTest.cs`](https://github.com/ivan-akira/acme-core-net-api/blob/main/Acme/Acme.UnitTest/Part_B_Stub/CalculatorTransactionActionTest.cs) and [`CalculatorTransactionActionTest_Alternative.cs`](https://github.com/ivan-akira/acme-core-net-api/blob/main/Acme/Acme.UnitTest/Part_B_Stub/CalculatorTransactionActionTest_Alternative.cs).

## Spy

Example of **Spy** class [🔗](https://github.com/ivan-akira/acme-core-net-api/blob/main/Acme/Acme.UnitTest/Part_C_Spy/TransportationTransactionActionTest.cs#L33-L45).
```csharp
        private class VehicleServiceSpy : IVehicleService // <- this is spy
        {
            public long StepMoveForward { get; set; }

            public void MoveForward(long step)
            {
                StepMoveForward = step;
            }

            public void MoveBackward(long step)
            {
            }
        }
```

Its usage in unit test [🔗](https://github.com/ivan-akira/acme-core-net-api/blob/main/Acme/Acme.UnitTest/Part_C_Spy/TransportationTransactionActionTest.cs#L16-L31).
```csharp
        [Fact]
        public void MoveVehicle_EndGreaterThanStartPosition_VehicleMoveForward()
        {
            // arrange
            var startPosition = 10L;
            var endPosition = 13L;
            var expectedStep = 3L;

            var vehicleService = new VehicleServiceSpy();

            // act
            transportationTransactionAction.MoveVehicle(startPosition, endPosition, vehicleService);

            // assert
            Assert.Equal(expectedStep, vehicleService.StepMoveForward);
        }
```

See the whole **Spy** examples on [`TransportationTransactionActionTest.cs`](https://github.com/ivan-akira/acme-core-net-api/blob/main/Acme/Acme.UnitTest/Part_C_Spy/TransportationTransactionActionTest.cs) and [`TransportationTransactionActionTest_Alternative.cs`](https://github.com/ivan-akira/acme-core-net-api/blob/main/Acme/Acme.UnitTest/Part_C_Spy/TransportationTransactionActionTest_Alternative.cs).

## Mock

Example of **Mock** object [🔗](https://github.com/ivan-akira/acme-core-net-api/blob/main/Acme/Acme.UnitTest/Part_D_Mock/RestaurantTransactionActionTest.cs#L11).
```csharp
        private readonly Mock<IKitchenTransactionAction> kitchenTransactionAction; // <- this is mock
```

Its usage in unit test [🔗](https://github.com/ivan-akira/acme-core-net-api/blob/main/Acme/Acme.UnitTest/Part_D_Mock/RestaurantTransactionActionTest.cs#L19-L33).
```csharp
        [Fact]
        public void OrderTakeoutMeals_OrderOneMeal_ReceiveOneMeal()
        {
            // arrange
            var quantity = 1;
            var expectedQuantity = 1;

            kitchenTransactionAction.Setup(k => k.DoCookMeal()).Returns(new MealEntity());

            // act
            var result = restaurantTransactionAction.OrderTakeoutMeals(quantity);

            // assert
            Assert.Equal(expectedQuantity, result.Count);
        }
```

See the whole **Mock** example on [`RestaurantTransactionActionTest.cs`](https://github.com/ivan-akira/acme-core-net-api/blob/main/Acme/Acme.UnitTest/Part_D_Mock/RestaurantTransactionActionTest.cs).

## Fake

Example of **Fake** class [🔗](https://github.com/ivan-akira/acme-core-net-api/blob/main/Acme/Acme.UnitTest/Part_E_Fake/PostalTransactionActionTest.cs#L30-L55).
```csharp
        private class NotificationProxyFake : INotificationProxy // <- this is fake
        {
            private readonly List<EmailResponseEntity> emails;

            public NotificationProxyFake()
            {
                emails = new List<EmailResponseEntity>();
            }

            public void AddEmailToQueue(SendEmailRequestEntity sendEmailRequestEntity)
            {
                emails.Add(new EmailResponseEntity()
                {
                    EmailId = Guid.NewGuid(),
                    From = sendEmailRequestEntity.From,
                    To = sendEmailRequestEntity.To,
                    Subject = sendEmailRequestEntity.Subject,
                    Body = sendEmailRequestEntity.Body
                });
            }

            public List<EmailResponseEntity> GetAllEmails()
            {
                return emails;
            }
        }
```

Its usage in unit test [🔗](https://github.com/ivan-akira/acme-core-net-api/blob/main/Acme/Acme.UnitTest/Part_E_Fake/PostalTransactionActionTest.cs#L14-L28).
```csharp
        [Fact]
        public void IsEmailPrepared_PrepareEmailBeforehand_ReturnTrue()
        {
            // arrange
            var notificationApiClient = new NotificationProxyFake();
            postalTransactionAction = new PostalTransactionAction(notificationApiClient);

            postalTransactionAction.PrepareEmail();

            // act
            var result = postalTransactionAction.IsEmailPrepared();

            // assert
            Assert.True(result);
        }
```

See the whole **Fake** example on [`PostalTransactionActionTest.cs`](https://github.com/ivan-akira/acme-core-net-api/blob/main/Acme/Acme.UnitTest/Part_E_Fake/PostalTransactionActionTest.cs).

[^1]: Fowler, Martin. “bliki: Test Double.” martinfowler.com, [martinfowler.com/bliki/TestDouble.html](https://martinfowler.com/bliki/TestDouble.html).

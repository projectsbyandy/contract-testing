// import { Pact } from '@pact-foundation/pact';
// import { StockService } from '../../stockservice';

// const provider = new Pact({
//   consumer: 'UserServiceConsumer',
//   provider: 'UserServiceProvider',
//   port: 1234,
// });

// describe('Pact with UserService', () => {
//   beforeAll(() => provider.setup());
//   afterAll(() => provider.finalize());

//   describe('when a request for a user is made', () => {
//     beforeAll(() =>
//       provider.addInteraction({
//         state: 'user exists',
//         uponReceiving: 'a request for a user',
//         withRequest: {
//           method: 'GET',
//           path: '/user/1',
//           headers: { Accept: 'application/json' },
//         },
//         willRespondWith: {
//           status: 200,
//           headers: { 'Content-Type': 'application/json' },
//           body: { id: 1, name: 'John Doe' },
//         },
//       })
//     );

//     it('will receive the user details', async () => {
//       let stockService = new StockService("https://localhost:7194/");
//       const user = await stockService.getStock("CT800");
//       expect(user).toEqual({ id: 1, name: 'John Doe' });
//     });
//   });
// });
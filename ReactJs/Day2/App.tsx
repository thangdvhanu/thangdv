import './App.css';
import './component.css';

let itemsInCountingList = [
  {
    icon: 'fas fa-microphone',
    number: '36+',
    text: 'Unique Session'
  },
  {
    icon: 'fas fa-user',
    number: '12',
    text: 'Amazing Speakers'
  },
  {
    icon: 'fas fa-book',
    number: '45',
    text: 'Food Stalls'
  },
  {
    icon: 'fas fa-coffee',
    number: '2350+',
    text: 'Books Available'
  }
];

let itemsInPricingTable = [
  {
    icon: 'fab fa-opencart',
    name: 'Basic',
    price: '$100',
    isTaxIncluded: true,
    benefits: [
      {
        isIncluded: true,
        name: '01 Seat'
      },
      {
        isIncluded: false,
        name: 'Tea & Coffee Breaks'
      },
      {
        isIncluded: false,
        name: 'Wifi Available'
      },
      {
        isIncluded: false,
        name: 'Exclusive Seatings'
      }
    ]
  },
  {
    icon: 'fas fa-user-tie',
    name: 'Standard',
    price: '$200',
    isTaxIncluded: true,
    benefits: [
      {
        isIncluded: true,
        name: '01 Seat'
      },
      {
        isIncluded: true,
        name: 'Tea & Coffee Breaks'
      },
      {
        isIncluded: false,
        name: 'Wifi Available'
      },
      {
        isIncluded: false,
        name: 'Exclusive Seatings'
      }
    ]
  },
  {
    icon: 'fas fa-rocket',
    name: 'Premium',
    price: '$300',
    isTaxIncluded: true,
    benefits: [
      {
        isIncluded: true,
        name: '01 Seat'
      },
      {
        isIncluded: true,
        name: 'Tea & Coffee Breaks'
      },
      {
        isIncluded: true,
        name: 'Wifi Available'
      },
      {
        isIncluded: true,
        name: 'Exclusive Seatings'
      }
    ]
  }
]

function CountingItemList() {
  return (
    <div className="items">
      {itemsInCountingList.map((item) => (
        <div className="item">
          <div className="item-icon">
            <i className={item.icon}></i>
          </div>
          <div className="item-right">
            <div className="item-bold-text">{item.number}</div>
            <div className="item-text">{item.text}</div>
          </div>
        </div>
      ))}
    </div>
  )
}
function PricingTable() {
  return (
    <div className="packs row text-center align-items-end">
      {itemsInPricingTable.map((pack) => (
        <div className="pack col-lg-4 mb-5 mb-lg-0">
          <div className="bg-white p-5 rounded-lg shadow">
            <div className="pack-icon">
              <i className={pack.icon}></i>
            </div>
            <div className="pack-name text-uppercase font-bold">{pack.name}</div>
            <div className="pack-price font-bold">
              <h2>{pack.price}</h2>
            </div>
            <div className="pack-tax font-bold text-muted">
              <h6>{pack.isTaxIncluded ? 'including all taxes' : 'not including all taxes'}</h6>
            </div>
            <ul className="list-unstyled my-5 text-small text-left">
              {pack.benefits.map((benefit)=>(
                <li className="mb-3">
                <i className={benefit.isIncluded?'fa fa-check mr-2 text-primary':'fa fa-times mr-2 text-muted'}></i>
                <span className={benefit.isIncluded?'font-bold':'text-muted'}>{benefit.name}</span>
              </li>
              ))}
            </ul>
            <a href="abc.com" className="btn btn-primary btn-block p-2 shadow rounded-pill">
              <i className="fas fa-shopping-basket"></i>
              <span>Buy Now</span>
            </a>
          </div>
        </div>
      ))}
    </div>
  )
}
// function Hello(props: any) {
//   return <h1 style={props.style}>Hello, {props.name}</h1>
// }

function App() {

  return (
    <div className="App">
      <CountingItemList></CountingItemList>
      <br/>
      <PricingTable></PricingTable>
      {/* <Hello style={{ color: 'red' }} name="Nashtech Interns"></Hello> */}
    </div>
  );
}

export default App;
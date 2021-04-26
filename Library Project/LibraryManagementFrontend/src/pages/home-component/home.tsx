import axios from "axios";
import React from "react";
import { Link, useHistory } from "react-router-dom";
import { AuthenticationSerivce } from "../../services/AuthenticationSerivce";

export function Home() {
  let history = useHistory();
  // const service = new AuthenticationSerivce();
  let onLogout = () => {
    axios.post("https://localhost:5001/logout")
      .then((res) => {
        if (res.status === 200) {
          sessionStorage.clear();
          history.push("/");
          // history.go(0);
          alert("Logout successfully!");
        }
      });
  };

  return (
    <div>
      <nav className="navbar navbar-expand-lg navbar-light bg-light">
        <div className="container-fluid">
          <div className="collapse navbar-collapse" id="navbarSupportedContent">
            <ul className="navbar-nav me-auto mb-2 mb-lg-0">
              <li className="nav-item">
                <Link to="/category" className="nav-link active" aria-current="page">Category</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link active" to="/book">Book</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link active" to="/request">Book Request</Link>
              </li>
              <li className="nav-item" onClick={() => { onLogout() }}>
                <Link className="nav-link active" to="/" onClick={() => { onLogout() }}>Logout</Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>
    </div>
  );
}

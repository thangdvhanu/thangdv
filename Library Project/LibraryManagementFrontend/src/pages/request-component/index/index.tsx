import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { RequestService } from '../../../services/RequestService';
import { Request } from '../../../types/request';

export function RequestList() {
  const [requests, setRequest] = useState<Request[]>([]);
  let role = sessionStorage.getItem("role");
  let userId = JSON.parse(sessionStorage.getItem("id")!);
  let i: number = 1;
  const service = new RequestService();
  const [update, setUpdate] = useState(false);
  useEffect(() => {
    if (role === "Admin") {
      (async () => {
        let requests = await service.getRequests();
        setRequest(requests);
      })();
    }
    else {
      (async () => {
        let requests = await service.getRequestByUserId(userId);
        setRequest(requests);
      })();
    }
  }, [update]);

  let onApprove = (id: number) => {
    (async () => {
      await service.aprrove(userId, id);
      setUpdate(pre => !pre);
    })();
  };
  let onReject = (id: number) => {
    (async () => {
      await service.reject(userId, id);
      setUpdate(pre => !pre);
    })();
  };

  return (
    <div>
      <Link to={`/create/request`}>Make Request</Link>
      <table className="table">
        <thead>
          <tr>
            <th scope="col">#</th>
            {sessionStorage.getItem("role") === "Admin" &&
              <th scope="col">Request User</th>
            }
            <th scope="col">Request Date</th>
            <th scope="col">Status</th>
            <th scope="col">Action</th>
          </tr>
        </thead>
        {requests && requests.length > 0 && requests.map((request: Request) => (
          <tbody key={i}>
            <tr>
              <th>{i++}</th>
              {sessionStorage.getItem("role") === "Admin" &&
                <th>{request.requestUser.username}</th>
              }
              <th>{request.requestDate}</th>
              {request.status === 0 && <th><p style={{ color: 'yellow' }}>Pending</p></th>}
              {request.status === 1 && <th><p style={{ color: 'blue' }}>Approved</p></th>}
              {request.status === 2 && <th><p style={{ color: 'red' }}>Rejected</p></th>}
              {sessionStorage.getItem("role") === "Member" &&
                <th>
                  <Link to={`/details/request/` + request.id}><button>Details</button></Link>
                </th>
              }
              {sessionStorage.getItem("role") === "Admin" && (request.status === 1 || request.status === 2) &&
                <th>
                  <Link to={`/details/request/` + request.id}><button>Details</button></Link>
                </th>
              }
              {sessionStorage.getItem("role") === "Admin" && request.status === 0 &&
                <th>
                  <Link to={`/details/request/` + request.id}><button>Details</button></Link>
                  <button className="btn btn-primary" onClick={() => { onApprove(request.id) }}>Approve</button>
                  <button className="btn btn-danger" onClick={() => { onReject(request.id) }}>Reject</button>
                </th>
              }
            </tr>
          </tbody>
        ))}
      </table>
    </div >
  );
}

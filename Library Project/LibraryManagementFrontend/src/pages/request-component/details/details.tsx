import React, { useEffect, useState } from "react";
import { Link, useHistory, useParams } from "react-router-dom";
import { RequestService } from "../../../services/RequestService";
import { Detail, Request } from "../../../types/request";

export function RequestDetails() {
  const [request, setRequest] = useState<Request>();
  let { requestId } = useParams<any>();
  let userId = JSON.parse(sessionStorage.getItem("id")!);
  const service = new RequestService();
  let history = useHistory();
  useEffect(() => {
    (async () => {
      let request = await service.getRequest(requestId);
      setRequest(request);
    })();
  }, []);

  let onApprove = (id: number) => {
    (async () => {
      await service.aprrove(userId, id);
      history.push("/request");
    })();
  };
  let onReject = (id: number) => {
    (async () => {
      await service.reject(userId, id);
      history.push("/request");
    })();
  };
  return (
    <div>
      <div className="row " >
        {request &&
          request.requestDetails.map((detail: Detail) => (
            <div className="col-md-4 book " key={detail.id}>
              <div>
                <img className="imgBook" src={detail.book.url} alt="Book" />
                <div >
                  <h5 > {detail.book.title}</h5>
                </div>
              </div>
            </div>
          ))}
      </div>
      <div>
        {request && sessionStorage.getItem("role") === "Admin" && request.status === 0 &&
          <>
            <button className="btn btn-primary" onClick={() => { onApprove(requestId) }}>Approve</button>
            <button className="btn btn-danger" onClick={() => { onReject(requestId) }}>Reject</button>
          </>
        }
        <Link className="btn btn-primary" to={`/request`}>Return</Link></div>
    </div >
  );
}

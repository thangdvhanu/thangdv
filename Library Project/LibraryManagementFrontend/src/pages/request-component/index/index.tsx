import { DislikeOutlined, LikeOutlined, SnippetsOutlined } from '@ant-design/icons';
import { Button, Popconfirm, Space, Table, Tag } from 'antd';
import Column from 'antd/lib/table/Column';
import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { RequestService } from '../../../services/RequestService';
import { Request } from '../../../models/request';

export function RequestList() {
  const service = new RequestService();
  const [update, setUpdate] = useState(false);
  let OnApprove = (id: number) => {
    (async () => {
      await service.aprrove(userId, id);
      setUpdate(pre => !pre);
    })();
  };
  let OnReject = (id: number) => {
    (async () => {
      await service.reject(userId, id);
      setUpdate(pre => !pre);
    })();
  };

  const [requests, setRequest] = useState<Request[]>([]);
  let role = sessionStorage.getItem("role");
  let userId = JSON.parse(sessionStorage.getItem("id")!);
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
  }, [update, ]);

  return (
    <>
      {requests && requests.length > 0 &&
        <Table key="table" dataSource={requests} pagination={{ defaultPageSize: 7 }}>
          {sessionStorage.getItem("role") === "Admin" &&
            <Column
              align='center'
              title="Request User"
              dataIndex="requestUser"
              key="requestUser"
              render={(requestUser) => {
                return (
                  requestUser.username
                );
              }}
            />
          }
          <Column align='center' title="Request Date" dataIndex="requestDate" key="requestDate" />
          <Column
            align='center'
            title="Status"
            dataIndex="status"
            key="status"
            render={(status) => {
              return (
                <>
                  {status === 0 && <Tag color="yellow" key={status}>Pending</Tag>}
                  {status === 1 && <Tag color="green" key={status}>Approved</Tag>}
                  {status === 2 && <Tag color="red" key={status}>Rejected</Tag>}
                </>
              );
            }}
          />
          <Column
            align='center'
            title="Action"
            dataIndex='id'
            key="action"
            render={(text, record: any, index) => {
              return (
                <Space size="middle">
                  <Button icon={<SnippetsOutlined />} size='middle'>
                    <Link style={{ color: 'black' }} to={`/request/details/${record.id}`}>Detail</Link>
                  </Button>
                  {sessionStorage.getItem("role") === "Admin" && record.status === 0 &&
                  <>
                    <Popconfirm title="Approve?" onConfirm={() => { OnApprove(record.id); }}>
                      <Button icon={<LikeOutlined style={{color:'blue'}} />} size='middle'>
                        Approve
                  </Button>
                    </Popconfirm>
                    <Popconfirm title="Reject?" onConfirm={() => { OnReject(record.id); }}>
                      <Button icon={<DislikeOutlined style={{color:'red'}} />} size='middle'>
                        Approve
                  </Button>
                    </Popconfirm>
                    </>
                  }
                </Space>
              );
            }}
          />
        </Table>}
    </>
    // <div>
    //   <Link to={`/create/request`}>Make Request</Link>
    //   <table className="table">
    //     <thead>
    //       <tr>
    //         <th scope="col">#</th>
    //         {sessionStorage.getItem("role") === "Admin" &&
    //           <th scope="col">Request User</th>
    //         }
    //         <th scope="col">Request Date</th>
    //         <th scope="col">Status</th>
    //         <th scope="col">Action</th>
    //       </tr>
    //     </thead>
    //     {requests && requests.length > 0 && requests.map((request: Request) => (
    //       <tbody key={i}>
    //         <tr>
    //           <th>{i++}</th>
    //           {sessionStorage.getItem("role") === "Admin" &&
    //             <th>{request.requestUser.username}</th>
    //           }
    //           <th>{request.requestDate}</th>
    //           {request.status === 0 && <th><p style={{ color: 'yellow' }}>Pending</p></th>}
    //           {request.status === 1 && <th><p style={{ color: 'blue' }}>Approved</p></th>}
    //           {request.status === 2 && <th><p style={{ color: 'red' }}>Rejected</p></th>}
    //           {sessionStorage.getItem("role") === "Member" &&
    //             <th>
    //               <Link to={`/request/details/` + request.id}><button>Details</button></Link>
    //             </th>
    //           }
    //           {sessionStorage.getItem("role") === "Admin" && (request.status === 1 || request.status === 2) &&
    //             <th>
    //               <Link to={`/request/details/` + request.id}><button>Details</button></Link>
    //             </th>
    //           }
    //           {sessionStorage.getItem("role") === "Admin" && request.status === 0 &&
    //             <th>
    //               <Link to={`/request/details/` + request.id}><button>Details</button></Link>
    //               <button className="btn btn-primary" onClick={() => { onApprove(request.id) }}>Approve</button>
    //               <button className="btn btn-danger" onClick={() => { onReject(request.id) }}>Reject</button>
    //             </th>
    //           }
    //         </tr>
    //       </tbody>
    //     ))}
    //   </table>
    // </div >
  );
}

import { } from "module";
import {
  DeleteOutlined,
  ExclamationCircleOutlined,
  InfoCircleOutlined,
} from '@ant-design/icons'
import { useEffect, useState } from "react";
import axios from "axios";
import { Post } from "../../models/Post";
import { Button, Col, Modal, Row, Table } from "antd";

const { confirm } = Modal

export function ListPost() {
  let [posts, setPosts] = useState<Post[]>([]);
  let [isFetchingData, setIsFetchingData] = useState(false);
  let [update, setUpdate] = useState(false);


  async function generateDetailedPostContent(record: Post) {
    Modal.info({
      title: `Detail of Post No. ${record.id}`,
      width: 1000,
      content: (
        <div>
          <p>ID : {record.id}</p>
          <p>Title : {record.title}</p>
          <p>Body : {record.body}</p>
        </div>
      ),
      onOk() { },
    })
  }

  function deletePost(record: Post) {
    confirm({
      title: 'Do you want to delete this post?',
      icon: <ExclamationCircleOutlined />,
      onOk() {
        let index = posts.indexOf(record);
        posts.splice(index, 1);
        setUpdate(pre => !pre);
      }
    }
    )
  };

  useEffect(() => {
    (async () => {
      setIsFetchingData(true);
      axios.get("https://jsonplaceholder.typicode.com/posts").then((response) => {
        setPosts(response.data);
        setIsFetchingData(false);
      });
    })()
  }, [update]);
  const columns: any = [
    {
      title: 'ID',
      dataIndex: 'id',
      key: 'id',
      width: 100
    },
    {
      title: 'Title',
      dataIndex: 'title',
      key: 'title',
      width: 1100,
      sorter: (a: Post, b: Post) => a.title.localeCompare(b.title),
      sortDirections: ['ascend', 'descend'],
    },
    {
      title: 'Actions',
      dataIndex: 'action',
      key: 'action',
      render: (text: any, record: Post, index: number) => {
        return (
          <Row>
            <Col offset={1}>
              <Button
                ghost
                type="link"
                title="Detail"
                icon={<InfoCircleOutlined />}
                onClick={() => generateDetailedPostContent(record)}
              />
            </Col>
            <Col offset={1}>
              <Button
                danger
                type="link"
                title="Delete"
                icon={<DeleteOutlined />}
                onClick={() => deletePost(record)}
              />
            </Col>
          </Row>
        )
      },
    },
  ]

  return (
    <>
      <>
        <Table
          dataSource={posts}
          columns={columns}
          scroll={{ y: 500 }}
          loading={isFetchingData}
        />
      </>
    </>
  )
}

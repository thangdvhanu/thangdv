import '../components/component.css';

interface NotificationList {
    Notifications: string[];
}

export function Notification(props: NotificationList) {
    const { Notifications } = props;
    return (
        <div className="container">
            <div className="noti-header text-uppercase text-muted">notifications</div>
            <div className="noti-text">Control your notification and auto-follow settings.</div>
            <div className="noti-box form-check form-switch col-lg-3 col-md-3">
                {Notifications.map(item => (
                    <>
                        <div className="noti-info">
                            <label className="form-check-label fw-bold">{item}</label>
                            <span></span>
                            <label className="form-check-label">Commits data and history</label>
                        </div>
                        <div className="noti-checkbox">
                            <input className="form-check-input" type="checkbox"></input>
                        </div>
                    </>
                ))}
            </div>
        </div>
    )
}
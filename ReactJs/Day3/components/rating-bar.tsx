import React, { useState } from 'react';
import '../components/component.css'

interface RatingNumber {
    RatingNumbers: number[]
}
export function RatingBar(props: RatingNumber) {
    const { RatingNumbers } = props;
    const [value, setValue] = useState(0);
    const [valueOnClick, setValueOnClick] = useState(0);
    return (
        <div className="container">
            <div className="bar-header fw-bolder">Rating Bar</div>
            <div className="current-box-value fw-bolder">{valueOnClick === 0 ? value : valueOnClick}</div>
            <div className="boxes">
                {RatingNumbers.map(item => (
                    <div className={item <= value || item <= valueOnClick ? "box-onhover" : "box"}
                        onClick={() => setValueOnClick(item)}
                        onMouseEnter={() => setValue(item)}
                        onMouseLeave={() => setValue(0)}
                    >
                        {item}
                    </div>
                ))}
            </div>
        </div>
    )
}
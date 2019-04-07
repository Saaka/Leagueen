import React from "react";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker-cssmodules.css";
import "./DateSelect.scss";

function DateSelect(props) {

    return (
        <>
            <DatePicker
                className="custom-datepicker"
                calendarClassName="custom-calendar-datepicker"
                dateFormat="dd/MM/yyyy"
                selected={props.date}
                onChange={props.onChange} />
        </>
    );
};

export { DateSelect };
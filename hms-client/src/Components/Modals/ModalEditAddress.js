import React, { Component } from 'react';
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';

export class ModalEditAddress extends Component {

    constructor(props) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(eventArgs) {
        eventArgs.preventDefault();
        fetch(process.env.REACT_APP_API + "addresses", {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ 
                addressId: this.props.addressId,
                city: eventArgs.target.City.value,
                street: eventArgs.target.Street.value,
                buildingNumber: eventArgs.target.BuildingNumber.value
            })
        })
        .then(response => {
            alert(response.status);
        });
    }

    render() {
        return (
            <div className="container">
                <Modal {...this.props} size="lg" aria-labelledby="contained-modal-title-vcenter" cerntred>
                    <Modal.Header closeButton>
                        <Modal.Title id="contained-modal-title-vcenter">
                            Edit address
                        </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Row>
                            <Col sm={6}>
                                <Form onSubmit={this.handleSubmit}>
                                    <Form.Group controlId="City">
                                        <Form.Label>City</Form.Label>
                                        <Form.Control type="text" name="City" required placeholder="City" 
                                            defaultValue={this.props.city}/>
                                    </Form.Group>
                                    <Form.Group controlId="Street">
                                        <Form.Label>Street</Form.Label>
                                        <Form.Control type="text" name="Street" required placeholder="Street" 
                                            defaultValue={this.props.street}/>
                                    </Form.Group>
                                    <Form.Group controlId="BuildingNumber">
                                        <Form.Label>Building number</Form.Label>
                                        <Form.Control type="text" name="BuildingNumber" required placeholder="Building number" 
                                            defaultValue={this.props.buildingNumber}/>
                                    </Form.Group>
                                    <Form.Group>
                                        <Button variant="primary" type="submit">Submit</Button>
                                    </Form.Group>
                                </Form>
                            </Col>
                        </Row>
                    </Modal.Body>
                    <Modal.Footer>
                        <Button variant="danger" onClick={this.props.onHide}>Close</Button>
                    </Modal.Footer>
                </Modal>
            </div>
        );
    }
}
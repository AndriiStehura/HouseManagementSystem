import React, { Component } from 'react';
import { Table, Button, ButtonToolbar } from 'react-bootstrap';
import { ModalAddAddress } from '../Components/Modals/ModalAddAddress';
import { ModalEditAddress } from '../Components/Modals/ModalEditAddress';

export class Addresses extends Component {

    constructor(props) {
        super(props);
        this.state = {
            addresses: [],
            addModalShow: false,
            editModalShow: false,
            currentAddr: {}
        }
    }

    refreshList() {
        fetch(process.env.REACT_APP_API + "addresses")
            .then(response => {
                console.log(response)
                return response.json()
            })
            .then(data => {
                this.setState({ addresses: data });
            });
    }

    componentDidMount() {
        this.refreshList();
    }

    componentDidUpdate() {
        this.refreshList();
    }

    render() {
        const { addresses, addr } = this.state;
        let addModalClose = () => this.setState({ addModalShow: false });
        let editModalClose = () => this.setState({ editModalShow: false });
        return (
            <div>
                <Table stripped="true" bordered hover size="sm" className="m-10">
                    <thead>
                        <tr>
                            <th>
                                Місто
                            </th>
                            <th>
                                Вулиця
                            </th>
                            <th>
                                Номер будинку
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {addresses.map(addr =>
                            <tr key={addr.addressId}>
                                <td>{addr.city}</td>
                                <td>{addr.street}</td>
                                <td>{addr.buildingNumber}</td>
                                <td>
                                    <ButtonToolbar>
                                        <Button className="mr-2" variant="info" 
                                            onClick={()=> {this.setState({editModalShow : true, currentAddr : addr})}}>
                                            Edit
                                        </Button>
                                        <ModalEditAddress show={this.state.editModalShow} onHide={editModalClose}
                                            addressId={this.state.currentAddr.addressId} city={this.state.currentAddr.city} 
                                            street={this.state.currentAddr.street} 
                                            buildingNumber={this.state.currentAddr.buildingNumber}/>
                                    </ButtonToolbar>
                                </td>
                            </tr>)}
                    </tbody>
                </Table>
                <ButtonToolbar>
                    <Button variant="primary" onClick={() => this.setState({ addModalShow: true })}>
                        Add address
                    </Button>
                    <ModalAddAddress show={this.state.addModalShow} onHide={addModalClose} />
                </ButtonToolbar>
            </div>
        );
    }
}
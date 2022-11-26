import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

export class OrderCategories extends Component {
    static displayName = OrderCategories.name;

  constructor(props) {
    super(props);
      this.state = { ordercategories: [], loading: true };
  }

  componentDidMount() {
      this.populateordercategoriesData();
  }

    static renderOrderCategoriesTable(ordercategories) {
    return (
      <table className="table table-striped" aria-labelledby="tableLabel">
        <thead>
          <tr>
            <th>Code</th>
            <th>Description</th>
            <th>Price</th>
          </tr>
        </thead>
        <tbody>
         {ordercategories.map(ordercategory =>
            <tr key={ordercategory.id}>
                <td>{ordercategory.code}</td>
                <td>{ordercategory.description}</td>
                <td>{ordercategory.price}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : OrderCategories.renderOrderCategoriesTable(this.state.ordercategories);

    return (
      <div>
        <h1 id="tableLabel">Order Categories List</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

async populateordercategoriesData() {
    const response = await fetch('ordercategory');
    const responseData = await response;
    console.log(responseData);
    const data = await response.json();
    this.setState({ ordercategories: data.items, loading: false });
  }
}

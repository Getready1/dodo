import React, { Component } from 'react'
import { Route } from 'react-router'
import { Layout } from './components/Layout'
import { category } from './models/TodoCategory'
import TodoContainer from './TodoContainer/TodoContainer'

export default class App extends Component {
  static displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path="/" render={() => <TodoContainer category={category.todo} />} />
        <Route exact path="/towatch" render={() => <TodoContainer category={category.towatch} />} />
        <Route exact path="/tobuy" render={() => <TodoContainer category={category.tobuy} />} />
        <Route exact path="/toread" render={() => <TodoContainer category={category.toread} />} />
      </Layout>
    )
  }
}

import { fetchGet, fetchPost, fetchPut, fetchDelete } from '../services/FetchService'
import React, { Component } from 'react'

import { Tab, Label, Icon, Segment } from 'semantic-ui-react'

import TodoList from '../components/TodoList/TodoList'
import TodoInput from '../components/Input/Input'

export default class TodoContainer extends Component {
  constructor(props) {
    super(props)

    this.state = {
      todos: null,
      activeTabIndex: 0
    }
  }

  addTodoItem = async content => {
    const newTodo = {
      content: content,
      isCompleted: false,
      category: this.props.category
    }

    const response = await fetchPost('api/todos', newTodo)

    if (response.ok) {
      const todo = await response.json()
      this.setState({ todos: [todo, ...this.state.todos] })
    }
  }

  markCompleted = async id => {
    const changedTodo = Object.assign({}, this.state.todos.find(t => t.id === id))
    changedTodo.isCompleted = !changedTodo.isCompleted

    const response = await fetchPut(`api/todos/${id}`, changedTodo)

    if (response.ok) {
      this.setState({
        todos: this.state.todos.map(td => {
          if (td.id === id) return changedTodo

          return td
        })
      })
    }
  }

  deleteTodoItem = async id => {
    const response = await fetchDelete(`api/todos/${id}`)

    if (response.ok) {
      this.setState({
        todos: this.state.todos.filter(td => td.id !== id)
      })
    }
  }

  async componentDidMount() {
    const response = await fetchGet('api/todos/')
    const todos = await response.json()

    this.setState({
      todos: todos.filter(t => t.category === this.props.category)
    })
  }

  fetchTodosForPane(filterFn) {
    const todos = this.state.todos.filter(filterFn)

    // this.setState({
    //   currentTodosCount: todos.length
    // })

    return todos
  }

  componentWillUpdate() {}

  panes = [
    {
      menuItem: 'Active',
      render: () => {
        return !this.state.todos ? (
          <Tab.Pane loading />
        ) : this.fetchTodosForPane(t => !t.isCompleted).length === 0 ? (
          <Tab.Pane>
            <div style={{ display: 'flex', justifyContent: 'center' }}>
              <h4>No todos yet :(</h4>
            </div>
          </Tab.Pane>
        ) : (
          <Tab.Pane>
            <TodoInput addTodoItem={this.addTodoItem} placeholder="What are we doing ?" />
            <TodoList todos={this.fetchTodosForPane(t => !t.isCompleted)} markCompleted={this.markCompleted} deleteTodoItem={this.deleteTodoItem} />
          </Tab.Pane>
        )
      }
    },
    {
      menuItem: 'Completed',
      render: () =>
        !this.state.todos ? (
          <Tab.Pane loading />
        ) : this.fetchTodosForPane(t => t.isCompleted).length === 0 ? (
          <Tab.Pane>
            <div style={{ display: 'flex', justifyContent: 'center' }}>
              <h4>Nothing completed yet :(</h4>
            </div>
          </Tab.Pane>
        ) : (
          <Tab.Pane>
            <TodoList todos={this.fetchTodosForPane(t => t.isCompleted)} markCompleted={this.markCompleted} deleteTodoItem={this.deleteTodoItem} />
          </Tab.Pane>
        )
    }
  ]

  handleTabChange = (e, { activeIndex }) => this.setState({ activeTabIndex: activeIndex })

  render() {
    return (
      <Segment>
        <Tab activeIndex={this.state.activeTabIndex} panes={this.panes} onTabChange={this.handleTabChange} />
        <Label>
          <Icon name="crosshairs" /> {this.state.todos == null ? 0 : this.state.todos.filter(t => (t.category === this.props.category && this.state.activeTabIndex ? t.isCompleted : !t.isCompleted)).length}
        </Label>
      </Segment>
    )
  }
}

import React from 'react'
import TodoItem from '../TodoItem/TodoItem'

export default function TodoList(props) {
  function RenderTodos() {
    return props.todos.map(td => {
      return <TodoItem key={td.id} id={td.id} content={td.content} isCompleted={td.isCompleted} markCompleted={props.markCompleted} deleteTodoItem={props.deleteTodoItem} />
    })
  }

  return <React.Fragment>{RenderTodos()}</React.Fragment>
}

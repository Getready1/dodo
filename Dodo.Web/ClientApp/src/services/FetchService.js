import { category } from '../models/TodoCategory'

const headers = {
  Accept: 'application/json',
  'Content-Type': 'application/json'
}

export function fetchGet(url) {
  // return GetPromise()
  return fetch(url)
}

export function fetchPost(url, body) {
  return fetch(url, {
    method: 'POST',
    headers: headers,
    body: JSON.stringify(body)
  })
}

export function fetchPut(url, body) {
  return fetch(url, {
    method: 'PUT',
    headers: headers,
    body: JSON.stringify(body)
  })
}

export function fetchDelete(url) {
  return fetch(url, {
    method: 'DELETE',
    headers: headers
  })
}

function GetPromise() {
  return new Promise((resolve, reject) => {
    resolve({
      ok: true,
      json: function() {
        return new Promise(resolve => {
          resolve([
            {
              id: 1,
              content: 'There are many variations of passages',
              isCompleted: true,
              category: category.todo
            },
            {
              id: 2,
              content: 'Many desktop publishing packages',
              isCompleted: false,
              category: category.toread
            },
            {
              id: 3,
              content: 'It was popularised in the 1960s',
              isCompleted: true,
              category: category.tobuy
            },
            {
              id: 4,
              content: 'Many desktop publishing packages',
              isCompleted: false,
              category: category.tobuy
            },
            {
              id: 5,
              content: 'It was popularised in the 1960s',
              isCompleted: true,
              category: category.tobuy
            }
          ])
        })
      }
    })
  })
}

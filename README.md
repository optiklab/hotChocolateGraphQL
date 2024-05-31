# hotChocolateGraphQL
Testing migration of HotChocolateGraphQL from 12 to 13

# How to test 

1. Run solution
2. Open Banana Cake Pop
3. Put http://localhost:5089/graphql as a schema server
4. Execute following requests in Tab 1:
```
subscription {
  onSessionScheduled {
    title
    startTime
  }
}
```
5. Execute following requests in Tab 2:
```
mutation AddSpeaker {
  addSpeaker(input: {
    name: "Speaker 1"
    bio: "Speaker 1"
    webSite: "http://speaker1.website" }) {
    speaker {
      id
    }
  }
}

mutation AddTrack {
  addTrack(input: { name: "Track 1" }) {
    track {
      id
      name
    }
  }
}

mutation AddSession {
  addSession(input: { title: "MySuperSession ", speakerIds: 1 }) {
    session {
      title
    }
  }
}

query GetSpeakerNames {
  speakers {
    nodes {
      bio
      id
      name
      webSite
    }
  }
}

query GetTracks {
  tracks {
    edges {
      node {
        id
        name
      }
      cursor
    }
    pageInfo {
      startCursor
      endCursor
      hasNextPage
      hasPreviousPage
    }
  }
}
query GetSessions {
  sessions {
    edges {
      node {
        id
        endTime
        startTime
        title
      }
      cursor
    }
    pageInfo {
      startCursor
      endCursor
      hasNextPage
      hasPreviousPage
    }
  }
}

mutation ScheduleSession {
  scheduleSession(
    input: {
      sessionId: 1
      trackId: 1
      startTime: "2024-05-01T17:00"
      endTime: "2024-05-01T17:00"
    }
  ) {
    session {
      title
    }
  }
}
```

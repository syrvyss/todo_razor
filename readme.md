# todo_razor

todo_razor is a c# implementation of an issue board, akin to GitHub issues or Jira

## Installation (macOS)

Use the package manager [brew](https://brew.sh/) to install dotnet.

```bash
brew install dotnet
```

## Contributing

* New features are only to be added using new branch called `feature/THIS_IS_A_NEW_FEATURE`
* `feature` brances are only to be merged into `develop`
* `develop` is never to be edited directly, except in case of syntax errors or other similar cases.
* `develop` is only to be merged into `master` when thorough testing has been made and all unit tests pass.

## Usage

### Running a live server

```bash
dotnet watch
```

### Run project normally

```bash
dotnet run
```

### Run unit tests

```bash
dotnet test
```

## TODO

- [x] Issue board page
- [x] User added features
- [x] Update issue support
- [ ] Better Error page
- [ ] Unit tests
- [ ] Integrate SQL Server



## License

[MIT](https://choosealicense.com/licenses/mit/)
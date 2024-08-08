﻿using Testcontainers.MongoDb;

namespace FoSouzaDev.Customers.IntegrationTests;

public sealed class MongoDbFixture : IAsyncLifetime
{
    private readonly MongoDbContainer _mongoDbContainer = new MongoDbBuilder().Build();

    public MongoDbContainer MongoDbContainer => _mongoDbContainer;
    //public IMongoDatabase MongoDatabase => new MongoClient(this.MongoDbContainer.GetConnectionString()).GetDatabase("testDb");

    public Task InitializeAsync() =>
        this._mongoDbContainer.StartAsync();

    public Task DisposeAsync() =>
        this._mongoDbContainer.DisposeAsync().AsTask();
}
// Test SignalR connection for Products
(function () {
    console.log('=== SignalR Test Script Loaded ===');

    // Test 1: Check ABP SignalR connection
    if (abp.signalr) {
        console.log('✅ ABP SignalR is available');
        console.log('Connection State:', abp.signalr.connectionState);
        console.log('Connection ID:', abp.signalr.connection?.connectionId);
    } else {
        console.log('❌ ABP SignalR is NOT available');
    }

    // Test 2: Connect to ProductHub
    var productConnection = new signalR.HubConnectionBuilder()
        .withUrl("/signalr-product")
        .build();

    // Listen for ProductCreated event
    productConnection.on("ProductCreated", function (data) {
        console.log('🔔 Product Created:', data);
        abp.notify.success(data.message);
    });

    // Listen for ReceiveProductUpdate
    productConnection.on("ReceiveProductUpdate", function (message) {
        console.log('🔔 Product Update:', message);
        abp.notify.info(message);
    });

    // Start connection
    productConnection.start()
        .then(function () {
            console.log('✅ Connected to ProductHub');
            console.log('Connection ID:', productConnection.connectionId);
        })
        .catch(function (err) {
            console.error('❌ ProductHub connection error:', err);
        });

    // Test 3: Send test message (uncomment to test)
    // setTimeout(function() {
    //     productConnection.invoke("SendProductUpdate", "Test message from client")
    //         .then(() => console.log('✅ Message sent'))
    //         .catch(err => console.error('❌ Send error:', err));
    // }, 2000);

    // Expose for testing in console
    window.productHub = productConnection;
    console.log('💡 Use window.productHub to test in console');
    console.log('Example: window.productHub.invoke("SendProductUpdate", "Hello!")');
})();

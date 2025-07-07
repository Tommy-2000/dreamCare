import 'package:cached_network_image/cached_network_image.dart';
import 'package:dreamcare_ehr_flutter/ui/screens/root/root_app.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:flutter_web_plugins/flutter_web_plugins.dart';

Future<void> main() async {

  // Ensure that all Flutter widgets are initialized
  WidgetsFlutterBinding.ensureInitialized();

  // Set the Url path strategy if the app is running in Web mode
  if (kIsWeb) {
    usePathUrlStrategy();
  }

  if (kDebugMode) {
    // Check image caching with network
    CachedNetworkImage.logLevel = CacheManagerLogLevel.debug;
  }


  runApp(ProviderScope(child: RootApp()));
}


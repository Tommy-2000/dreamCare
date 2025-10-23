import '../../common/cards/account_cards/account_card.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:flutter_staggered_grid_view/flutter_staggered_grid_view.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../logic/utils/constants.dart';
import '../../../styles/colours.dart';
import '../../common/cards/content_card.dart';

class AccountScreen extends ConsumerStatefulWidget {
  const AccountScreen({super.key});

  @override
  ConsumerState<AccountScreen> createState() => _AccountScreenState();
}

class _AccountScreenState extends ConsumerState<AccountScreen> {
  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      primary: false,
      padding: EdgeInsets.all(screenGridPadding),
      child: Column(
        children: [
          ContentCard(
            child: Row(
              children: [
                Text(
                  "Account",
                  style: GoogleFonts.montserrat(
                    fontSize: 25,
                    fontWeight: FontWeight.bold,
                    color: blackTextColour,
                  ),
                ),
              ],
            ),
          ),
          GridView.custom(
            clipBehavior: Clip.antiAlias,
            shrinkWrap: true,
            gridDelegate: SliverQuiltedGridDelegate(
              crossAxisCount: 32,
              pattern: [QuiltedGridTile(8, 16), QuiltedGridTile(8, 16)],
            ),
            childrenDelegate: SliverChildListDelegate([
              AccountCard(),
              AccountCard(),
            ]),
          ),
        ],
      ),
    );
  }
}
